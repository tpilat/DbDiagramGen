using DbDiagramGen.EAModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbDiagramGen
{
	public class DbGenerator
	{
		private readonly StringBuilder _sb;
		private readonly DbGenertorConfig _config;
		private readonly Envelope.Database.IModel _dbModel;
		private readonly EA.Repository _eaRepository;

		private Dictionary<string, EA.IDualPackage> _basePackagesMap;
		private Dictionary<string, EA.IDualPackage> _tableSchemaToPackageMap;
		private Dictionary<string, EA.IDualPackage> _viewSchemaToPackageMap;
		private Dictionary<string, EA.IDualDiagram> _tableSchemaToDiagramMap;
		private Dictionary<string, EA.IDualDiagram> _viewSchemaToDiagramMap;
		private Dictionary<string, EA.IDualElement> _tableToElementMap;
		private Dictionary<string, List<string>> _diagramElements;
		private EA.IDualPackage _eaModelPackage;
		//private Model _model;

		public DbGenerator(Envelope.Database.IModel model, EA.Repository repository, DbGenertorConfig config)
		{
			_sb = new StringBuilder();
			_dbModel = model;
			_eaRepository = repository;
			_config = config ?? new DbGenertorConfig();
		}

		public string Generate()
		{
			_sb.Clear();
			var eaRepo = new EARepository(_eaRepository);
			//eaRepo.Build();

			_eaModelPackage = eaRepo.WrappedCurrentEAPackage;
			_basePackagesMap = new Dictionary<string, EA.IDualPackage> { { "Model", _eaModelPackage } };
			_tableSchemaToPackageMap = new Dictionary<string, EA.IDualPackage>();
			_viewSchemaToPackageMap = new Dictionary<string, EA.IDualPackage>();
			_tableSchemaToDiagramMap = new Dictionary<string, EA.IDualDiagram>();
			_viewSchemaToDiagramMap = new Dictionary<string, EA.IDualDiagram>();
			_tableToElementMap = new Dictionary<string, EA.IDualElement>();
			_diagramElements = new Dictionary<string, List<string>>();

			CreatePackages();

			//_model = new Model(_eaRepository);

			foreach (var schema in _dbModel.Schemas)
				CreateDiagram(schema);

			foreach (var schema in _dbModel.Schemas)
				CreateReferences(schema, _config.FlipConnectors);

			var diagrams = _tableSchemaToDiagramMap.Values.ToList();
			diagrams.AddRange(_viewSchemaToDiagramMap.Values.ToList());

			foreach (var eaDiagram in diagrams)
			{
				//EA.ConstLayoutStyles.lsDiagramDefault
				_eaRepository.GetProjectInterface().LayoutDiagramEx(eaDiagram.DiagramGUID, int.MinValue, 50, 50, 50, true);
				//_eaRepository.GetProjectInterface().LayoutDiagramEx(eaDiagram.DiagramGUID, 0, 50, 50, 50, true);
				//_eaRepository.ReloadDiagram(eaDiagram.DiagramID);
				eaDiagram.Update();

				if (_config.UseAutoRoutingLineStyle)
				{
					foreach (EA.IDualDiagramLink link in eaDiagram.DiagramLinks)
					{
						link.LineStyle = EA.LinkLineStyle.LineStyleAutoRouting;
						link.Update();
					}
				}

				eaDiagram.Update();
				_eaRepository.CloseDiagram(eaDiagram.DiagramID);
			}

			foreach (var eaPackage in _tableSchemaToPackageMap.Values)
				eaPackage.Update();

			foreach (var eaPackage in _viewSchemaToPackageMap.Values)
				eaPackage.Update();

			foreach (var eaPackage in _basePackagesMap.Values)
				eaPackage.Update();

			return _sb.ToString();
		}

		private bool CreateDiagram(Envelope.Database.ISchema dbSchema)
		{
			bool created = false;

			if (dbSchema.Tables.Any())
			{
				_tableSchemaToPackageMap.TryGetValue(dbSchema.Alias, out var eaPackage);
				if (eaPackage == null)
				{
					_sb.AppendLine($"{nameof(CreateDiagram)} tables: {nameof(Envelope.Database.ISchema)} {dbSchema.Name} was not found.");
					return false;
				}

				EA.Diagram eaDiagram = eaPackage.Diagrams.AddNew(dbSchema.Name, "Logical");

				var updated = eaDiagram.Update();
				if (!updated)
				{
					_sb.AppendLine($"#1 schema = {dbSchema.Name} | Error = {eaDiagram.GetLastError()}");
					return false;
				}

				eaDiagram.ExtendedStyle = "HideRel=0;ShowTags=0;ShowReqs=0;ShowCons=0;OpParams=1;ShowSN=0;ScalePI=0;PPgs.cx=0;PPgs.cy=0;PSize=9;ShowIcons=1;SuppCN=0;HideProps=0;HideParents=0;UseAlias=0;HideAtts=0;HideOps=1;HideStereo=0;HideEStereo=0;ShowRec=0;ShowRes=0;ShowShape=1;FormName=;";
				eaDiagram.StyleEx = "ExcludeRTF=0;DocAll=0;HideQuals=0;AttPkg=1;ShowTests=0;ShowMaint=0;SuppressFOC=1;MatrixActive=0;SwimlanesActive=1;KanbanActive=0;MatrixLineWidth=1;MatrixLineClr=0;MatrixLocked=0;TConnectorNotation=UML 2.1;TExplicitNavigability=0;AdvancedElementProps=1;AdvancedFeatureProps=1;AdvancedConnectorProps=1;m_bElementClassifier=1;SPT=1;MDGDgm=Extended::Data Modeling;STBLDgm=;ShowNotes=0;SPL=S_41A982=4A3C16,AF6441,1D6274,C2DF1D,9908FF,9EB915,9B7FB8:S_BE00F1=3A4AF2,3EC8EF,3F89ED,F95666,79AF48,E7115D,C23DED,251D73,C399EC,FD43A6,EB5360,938542,2E7D60:S_862F41=9ED8A7,C80500,C4DA1D,B6DF31,3F768E,CD26F3,B8AFAE,B85A24,9D39E1,4603E1,A88AE5,977654,4E1707,DC737B,736487:S_68EBC1=AFCD7F,AA227F,4349FF,3ACF15,51C2F4,F3022F,BE0424,6C14E9,B3CEE3,6B2F71:S_ECCEC0=CC53E2,52BADA,671AF3,4DADCF,780FB4,24DDD5,D234A3,B90514,04783F,840227,53C102,ED4873,3BC844,2B4A8A,B91A2B,AF2CB1,0CE6A7,FA7E57,A40122,C274CD:S_7751BF=56E5E7,F3E952,91C1CA,B88D25,B533C7,A0A3C3,61D989,8E1473,FFDE07,BBB369:;VisibleAttributeDetail=0;ShowOpRetType=1;SuppressBrackets=0;SuppConnectorLabels=0;PrintPageHeadFoot=0;ShowAsList=0;SuppressedCompartments=;Theme=:119;SaveTag=4E4FD846;";
				eaDiagram.Swimlanes = "locked=false;orientation=0;width=0;inbar=false;names=false;color=-1;bold=false;fcol=0;tcol=-1;ofCol=-1;ufCol=-1;hl=0;ufh=0;hh=0;cls=0;bw=0;hli=0;bro=0;";
				eaDiagram.MetaType = "Extended::Data Modeling";

				updated = eaDiagram.Update();
				if (!updated)
				{
					_sb.AppendLine($"#2 schema = {dbSchema.Name} | Error = {eaDiagram.GetLastError()}");
					return false;
				}

				updated = eaPackage.Update();
				if (!updated)
				{
					_sb.AppendLine($"#3 schema = {dbSchema.Name} | Error = {eaDiagram.GetLastError()}");
					return false;
				}

				_tableSchemaToDiagramMap.Add(dbSchema.Alias, eaDiagram);
				var diagramClasses = new List<string>();

				foreach (var dbTable in dbSchema.Tables)
				{
					CreateTable(eaPackage, eaDiagram, dbTable);
					diagramClasses.Add(dbTable.Name);
				}

				_diagramElements.Add(dbSchema.Alias, diagramClasses);

				created = true;
			}

			if (dbSchema.Views.Any())
			{
				_viewSchemaToPackageMap.TryGetValue(dbSchema.Alias, out var eaPackage);
				if (eaPackage == null)
				{
					_sb.AppendLine($"{nameof(CreateDiagram)} views: {nameof(Envelope.Database.ISchema)} {dbSchema.Name} was not found.");
					return false;
				}

				EA.Diagram eaDiagram = eaPackage.Diagrams.AddNew(dbSchema.Name, "Logical");

				var updated = eaDiagram.Update();
				if (!updated)
				{
					_sb.AppendLine($"#11 schema = {dbSchema.Name} | Error = {eaDiagram.GetLastError()}");
					return false;
				}

				eaDiagram.ExtendedStyle = "HideRel=0;ShowTags=0;ShowReqs=0;ShowCons=0;OpParams=1;ShowSN=0;ScalePI=0;PPgs.cx=0;PPgs.cy=0;PSize=9;ShowIcons=1;SuppCN=0;HideProps=0;HideParents=0;UseAlias=0;HideAtts=0;HideOps=1;HideStereo=0;HideEStereo=0;ShowRec=0;ShowRes=0;ShowShape=1;FormName=;";
				eaDiagram.StyleEx = "ExcludeRTF=0;DocAll=0;HideQuals=0;AttPkg=1;ShowTests=0;ShowMaint=0;SuppressFOC=1;MatrixActive=0;SwimlanesActive=1;KanbanActive=0;MatrixLineWidth=1;MatrixLineClr=0;MatrixLocked=0;TConnectorNotation=UML 2.1;TExplicitNavigability=0;AdvancedElementProps=1;AdvancedFeatureProps=1;AdvancedConnectorProps=1;m_bElementClassifier=1;SPT=1;MDGDgm=Extended::Data Modeling;STBLDgm=;ShowNotes=0;SPL=S_41A982=4A3C16,AF6441,1D6274,C2DF1D,9908FF,9EB915,9B7FB8:S_BE00F1=3A4AF2,3EC8EF,3F89ED,F95666,79AF48,E7115D,C23DED,251D73,C399EC,FD43A6,EB5360,938542,2E7D60:S_862F41=9ED8A7,C80500,C4DA1D,B6DF31,3F768E,CD26F3,B8AFAE,B85A24,9D39E1,4603E1,A88AE5,977654,4E1707,DC737B,736487:S_68EBC1=AFCD7F,AA227F,4349FF,3ACF15,51C2F4,F3022F,BE0424,6C14E9,B3CEE3,6B2F71:S_ECCEC0=CC53E2,52BADA,671AF3,4DADCF,780FB4,24DDD5,D234A3,B90514,04783F,840227,53C102,ED4873,3BC844,2B4A8A,B91A2B,AF2CB1,0CE6A7,FA7E57,A40122,C274CD:S_7751BF=56E5E7,F3E952,91C1CA,B88D25,B533C7,A0A3C3,61D989,8E1473,FFDE07,BBB369:;VisibleAttributeDetail=0;ShowOpRetType=1;SuppressBrackets=0;SuppConnectorLabels=0;PrintPageHeadFoot=0;ShowAsList=0;SuppressedCompartments=;Theme=:119;SaveTag=4E4FD846;";
				eaDiagram.Swimlanes = "locked=false;orientation=0;width=0;inbar=false;names=false;color=-1;bold=false;fcol=0;tcol=-1;ofCol=-1;ufCol=-1;hl=0;ufh=0;hh=0;cls=0;bw=0;hli=0;bro=0;";
				eaDiagram.MetaType = "Extended::Data Modeling";

				updated = eaDiagram.Update();
				if (!updated)
				{
					_sb.AppendLine($"#12 schema = {dbSchema.Name} | Error = {eaDiagram.GetLastError()}");
					return false;
				}

				updated = eaPackage.Update();
				if (!updated)
				{
					_sb.AppendLine($"#13 schema = {dbSchema.Name} | Error = {eaDiagram.GetLastError()}");
					return false;
				}

				_viewSchemaToDiagramMap.Add(dbSchema.Alias, eaDiagram);

				foreach (var dbView in dbSchema.Views)
					CreateView(eaPackage, eaDiagram, dbView);

				created = true;
			}

			//TODO
			//foreach (var nestedSchema in dbSchema.NestedSchemas)
			//	created = CreateDiagram(nestedSchema) || created;

			return created;
		}

		private void CreateTable(EA.IDualPackage eaPackage, EA.Diagram eaDiagram, Envelope.Database.ITable dbTable)
		{
			EA.Element tableElement = eaPackage.Elements.AddNew(dbTable.Name, "Table");

			var updated = tableElement.Update();
			if (!updated)
			{
				_sb.AppendLine($"#1 dbTable = {dbTable.Name} | Error = {tableElement.GetLastError()}");
				return;
			}

			//tableElement.MetaType = "Table";
			//tableElement.Stereotype = "table";
			//tableElement.StereotypeEx = "table";
			tableElement.Gentype = "PostgreSQL"; //TODO: dbTable.Schema.Model.ProviderType.ToString();

			foreach (global::EA.IDualTaggedValue taggedValue in tableElement.TaggedValues)
			{
				if (taggedValue.Name == "Owner")
				{
					taggedValue.Value = dbTable.Schema.Alias;
					updated = taggedValue.Update();
					if (!updated)
					{
						_sb.AppendLine($"#2 taggedValue = Owner | dbTable = {dbTable.Name} | alias = {dbTable.Schema.Alias} | Error = {taggedValue.GetLastError()}");
						return;
					}

					break;
				}
			}

			//TODO
			//if (!string.IsNullOrWhiteSpace(dbTable.Description))
			//	tableElement.Notes = dbTable.Description;

			_tableToElementMap.Add(dbTable.Name, tableElement);

			var i = 0;
			foreach (var column in dbTable.Columns)
				CreateColumn(tableElement, column, i++);

			updated = tableElement.Update();
			if (!updated)
			{
				_sb.AppendLine($"#3 dbTable = {dbTable.Name} | Error = {tableElement.GetLastError()}");
				return;
			}

			if (dbTable.PrimaryKey != null)
			{
				EA.Method method = tableElement.Methods.AddNew(dbTable.PrimaryKey.Name, "");
				updated = method.Update();
				if (!updated)
				{
					_sb.AppendLine($"#11 dbTable = {dbTable.Name} | PK = {dbTable.PrimaryKey.Name} | Error = {tableElement.GetLastError()}");
					return;
				}

				method.Stereotype = "PK";
				updated = method.Update();
				if (!updated)
				{
					_sb.AppendLine($"#12 dbTable = {dbTable.Name} | PK = {dbTable.PrimaryKey.Name} | Error = {tableElement.GetLastError()}");
					return;
				}

				var firstColumn = dbTable.PrimaryKey.Columns.FirstOrDefault();
				if (firstColumn != null)
				{
					EA.Parameter parameter = method.Parameters.AddNew(firstColumn.Name, firstColumn.DatabaseType);
					parameter.Position = 0;
					updated = parameter.Update();
					if (!updated)
					{
						_sb.AppendLine($"#13 dbTable = {dbTable.Name} | PK = {dbTable.PrimaryKey.Name} | Error = {tableElement.GetLastError()}");
						return;
					}
				}

				updated = method.Update();
				if (!updated)
				{
					_sb.AppendLine($"#14 dbTable = {dbTable.Name} | PK = {dbTable.PrimaryKey.Name} | Error = {tableElement.GetLastError()}");
					return;
				}
			}

			var fkColumnIndexIds = new Dictionary<string, int>();

			if (dbTable.Indexes != null)
			{
				foreach (var index in dbTable.Indexes)
				{
					EA.Method method = tableElement.Methods.AddNew(index.Name, "");
					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#21 dbTable = {dbTable.Name} | PK = {index.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					method.Stereotype = "index";
					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#22 dbTable = {dbTable.Name} | PK = {index.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					var pos = 0;
					foreach (var column in index.Columns)
					{
						EA.Parameter parameter = method.Parameters.AddNew(column.Name, column.DatabaseType);
						parameter.Position = pos++;
						updated = parameter.Update();
						if (!updated)
						{
							_sb.AppendLine($"#23 dbTable = {dbTable.Name} | PK = {index.Name} | Error = {tableElement.GetLastError()}");
							return;
						}

						if (column.TargetForeignKey != null && !fkColumnIndexIds.ContainsKey(column.Name))
							fkColumnIndexIds.Add(column.Name, method.MethodID);
					}

					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#24 dbTable = {dbTable.Name} | PK = {index.Name} | Error = {tableElement.GetLastError()}");
						return;
					}
				}
			}

			if (dbTable.UniqueConstraints != null)
			{
				foreach (var unique in dbTable.UniqueConstraints)
				{
					EA.Method method = tableElement.Methods.AddNew(unique.Name, "");
					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#31 dbTable = {dbTable.Name} | PK = {unique.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					method.Stereotype = "unique";
					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#32 dbTable = {dbTable.Name} | PK = {unique.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					foreach (var column in unique.Columns)
					{
						var pos = 0;
						EA.Parameter parameter = method.Parameters.AddNew(column.Name, column.DatabaseType);
						parameter.Position = pos++;
						updated = parameter.Update();
						if (!updated)
						{
							_sb.AppendLine($"#33 dbTable = {dbTable.Name} | PK = {unique.Name} | Error = {tableElement.GetLastError()}");
							return;
						}
					}

					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#34 dbTable = {dbTable.Name} | PK = {unique.Name} | Error = {tableElement.GetLastError()}");
						return;
					}
				}
			}

			if (dbTable.ForeignKeys != null)
			{
				foreach (var foreignKey in dbTable.ForeignKeys)
				{
					EA.Method method = tableElement.Methods.AddNew(foreignKey.Name, "");
					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#41 dbTable = {dbTable.Name} | PK = {foreignKey.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					method.Stereotype = "FK";

					if (fkColumnIndexIds.TryGetValue(foreignKey.FromColumn.Name, out var indexMethodID))
						method.StyleEx = $"FKIDX={indexMethodID};";

					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#42 dbTable = {dbTable.Name} | PK = {foreignKey.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					EA.Parameter parameter = method.Parameters.AddNew(foreignKey.FromColumn.Name, foreignKey.FromColumn.DatabaseType);
					parameter.Position = 0;
					updated = parameter.Update();
					if (!updated)
					{
						_sb.AppendLine($"#43 dbTable = {dbTable.Name} | PK = {foreignKey.Name} | Error = {tableElement.GetLastError()}");
						return;
					}

					updated = method.Update();
					if (!updated)
					{
						_sb.AppendLine($"#44 dbTable = {dbTable.Name} | PK = {foreignKey.Name} | Error = {tableElement.GetLastError()}");
						return;
					}
				}
			}

			_eaRepository.SaveDiagram(eaDiagram.DiagramID);
			EA.DiagramObject newDiagramObject = eaDiagram.DiagramObjects.AddNew("", "");
			newDiagramObject.ElementID = tableElement.ElementID;
			newDiagramObject.Update();
			eaPackage.Update();
		}

		private void CreateView(EA.IDualPackage eaPackage, EA.Diagram eaDiagram, Envelope.Database.IView dbView)
		{
			EA.Element viewElement = eaPackage.Elements.AddNew(dbView.Name, "View");

			var updated = viewElement.Update();
			if (!updated)
			{
				_sb.AppendLine($"#1 dbView = {dbView.Name} | Error = {viewElement.GetLastError()}");
				return;
			}

			//viewElement.MetaType = "View";
			//viewElement.Stereotype = "view";
			//viewElement.StereotypeEx = "view";
			viewElement.Gentype = "PostgreSQL"; //TODO: dbView.Schema.Model.ProviderType.ToString();

			bool addedViewdef = false;
			foreach (global::EA.IDualTaggedValue taggedValue in viewElement.TaggedValues)
			{
				if (taggedValue.Name == "Owner")
				{
					taggedValue.Value = dbView.Schema.Alias;
					updated = taggedValue.Update();
					if (!updated)
					{
						_sb.AppendLine($"#1 taggedValue = Owner | dbView = {dbView.Name} | alias = {dbView.Schema.Alias} | Error = {taggedValue.GetLastError()}");
						return;
					}
				}
				else if (taggedValue.Name == "viewdef")
				{
					taggedValue.Notes = dbView.Definition;
					taggedValue.Value = "<memo>";
					updated = taggedValue.Update();
					if (!updated)
					{
						_sb.AppendLine($"#2 taggedValue = viewdef | dbView = {dbView.Name} | alias = {dbView.Schema.Alias} | Error = {taggedValue.GetLastError()}");
						return;
					}
				}
			}

			if (!addedViewdef)
			{
				var viewDefTaggedValue = viewElement.TaggedValues.AddNew("viewdef", "");
				updated = viewDefTaggedValue.Update();
				if (!updated)
				{
					_sb.AppendLine($"#3 taggedValue = viewdef | dbView = {dbView.Name} | alias = {dbView.Schema.Alias} | Error = {viewDefTaggedValue.GetLastError()}");
					return;
				}

				viewDefTaggedValue.Notes = dbView.Definition;
				viewDefTaggedValue.Value = "<memo>";
				updated = viewDefTaggedValue.Update();
				if (!updated)
				{
					_sb.AppendLine($"#4 taggedValue = viewdef | dbView = {dbView.Name} | alias = {dbView.Schema.Alias} | Error = {viewDefTaggedValue.GetLastError()}");
					return;
				}
			}

			//TODO
			//if (!string.IsNullOrWhiteSpace(dbView.Description))
			//	viewElement.Notes = dbView.Description;

			updated = viewElement.Update();
			if (!updated)
			{
				_sb.AppendLine($"#2 dbView = {dbView.Name} | Error = {viewElement.GetLastError()}");
				return;
			}

			_eaRepository.SaveDiagram(eaDiagram.DiagramID);
			EA.DiagramObject newDiagramObject = eaDiagram.DiagramObjects.AddNew("", "");
			newDiagramObject.ElementID = viewElement.ElementID;
			newDiagramObject.Update();
			eaPackage.Update();
		}

		private void CreateColumn(EA.Element tableElement, Envelope.Database.IColumn column, int position)
		{
			EA.Attribute eaAttribute = tableElement.Attributes.AddNew(column.Name, "");

			var updated = eaAttribute.Update();
			if (!updated)
			{
				_sb.AppendLine($"#1 dbTable = {tableElement.Name} | column = {column.Name} | Error = {eaAttribute.GetLastError()}");
				return;
			}

			eaAttribute.Pos = position;

			var isVarchar = column.DatabaseType.ToLower() == "character varying";
			eaAttribute.Type = isVarchar
				? "varchar"
				: column.DatabaseType;

			if (0 < column.CharacterMaximumLength)
				eaAttribute.Length = column.CharacterMaximumLength.ToString();

			if (column.Precision.HasValue)
				eaAttribute.Precision = column.Precision.Value.ToString();

			if (column.Scale.HasValue)
				eaAttribute.Scale = column.Scale.Value.ToString();

			//eaAttribute.Notes = column.Description; //TODO
			eaAttribute.IsID = column.IsIdentity;
			eaAttribute.Default = column.DefaultValue;
			eaAttribute.Stereotype = "column";

			if (column.PrimaryKey != null)
				eaAttribute.IsOrdered = true;

			if (column.IsNotNull)
				eaAttribute.AllowDuplicates = true;

			if (column.TargetForeignKey != null)
				eaAttribute.IsCollection = true;

			if (column.UniqueConstraints.Any())
				eaAttribute.IsStatic = true;

			updated = eaAttribute.Update();
			if (!updated)
			{
				_sb.AppendLine($"#2 dbTable = {tableElement.Name} | column = {column.Name} | Error = {eaAttribute.GetLastError()}");
				return;
			}

			updated = tableElement.Update();
			if (!updated)
			{
				_sb.AppendLine($"#3 dbTable = {tableElement.Name} | column = {column.Name} | Error = {tableElement.GetLastError()}");
				return;
			}
		}

		private void CreateReferences(
			Envelope.Database.ISchema schema,
			bool flipConnectors)
		{
			foreach (var dbTable in schema.Tables)
				CreateReferences(dbTable, flipConnectors);

			//foreach (var nestedNamespace in schema.NestedNamespaces)
			//	CreateReferences(nestedNamespace);
		}

		private void CreateReferences(
			Envelope.Database.ITable dbTable,
			bool flipConnectors)
		{
			if (!_tableSchemaToPackageMap.TryGetValue(dbTable.Schema.Alias, out var eaPackage))
			{
				_sb.AppendLine($"{nameof(CreateReferences)}: #Package# {nameof(Envelope.Database.ISchema)} {dbTable.Schema.Alias} was not found.");
				return;
			}

			if (!_tableSchemaToDiagramMap.TryGetValue(dbTable.Schema.Alias, out var eaDiagram))
			{
				_sb.AppendLine($"{nameof(CreateReferences)}: #Diagram# {nameof(Envelope.Database.ISchema)} {dbTable.Schema.Alias} was not found.");
				return;
			}

			if (!_tableToElementMap.TryGetValue(dbTable.Name, out var sourceTableElement))
			{
				_sb.AppendLine($"{nameof(CreateReferences)}: #Table# {nameof(Envelope.Database.ITable)} {dbTable.Name} was not found.");
				return;
			}

			if (!_diagramElements.TryGetValue(dbTable.Schema.Alias, out var currentDiagramTables))
			{
				_sb.AppendLine($"{nameof(CreateReferences)}: #diagram# {dbTable.Schema.Alias} was not found.");
				return;
			}

			var updated = false;
			foreach (var foreignKey in dbTable.ForeignKeys)
			{
				if (!_tableToElementMap.TryGetValue(foreignKey.ToColumn.Table.Name, out var targetTableElement))
				{
					_sb.AppendLine($"{nameof(CreateReferences)}: #ReferencedClass# {nameof(Envelope.Database.ITable)} {foreignKey.ToColumn.Table.Name} was not found.");
					continue;
				}

				//if target table is not in the same diagram as source table, add to the diagram
				if (!currentDiagramTables.Contains(foreignKey.ToColumn.Table.Name))
				{
					EA.DiagramObject newDiagramObject = eaDiagram.DiagramObjects.AddNew("", "");
					newDiagramObject.ElementID = targetTableElement.ElementID;
					newDiagramObject.BackgroundColor = 14474460; // 12500670;
					newDiagramObject.IsSelectable = true;
					newDiagramObject.Style = "DUID=369A096D;NSL=0;BFol=-1;LCol=-1;fontsz=0;bold=0;black=0;italic=0;ul=0;charset=0;pitch=0;HideIcon=0;BCol=14474460;LWth=0;AttPub=0;OpPub=0;AttCustom=0;OpCustom=0;RzO=1;";

					updated = newDiagramObject.Update();
					if (!updated)
					{
						_sb.AppendLine($"#1 {nameof(CreateReferences)}: foreignKey = {foreignKey.Name} | Error = {newDiagramObject.GetLastError()}");
						return;
					}

					currentDiagramTables.Add(foreignKey.ToColumn.Table.Name);
				}

				EA.Connector eaConnector = 
					CreateConnector(
						eaPackage,
						sourceTableElement,
						targetTableElement,
						foreignKey,
						flipConnectors);

				var labelLength = Convert.ToInt32(Math.Ceiling(Math.Max(foreignKey.ToColumn.Name.Length, foreignKey.FromColumn.Name.Length) * 5.5));
				EA.DiagramLink diagramLink = eaDiagram.DiagramLinks.AddNew("", "");
				diagramLink.ConnectorID = eaConnector.ConnectorID;
				diagramLink.Geometry = $"SX=0;SY=0;EX=0;EY=0;EDGE=2;$LLB=CX=17:CY=14:OX=0:OY=0:HDN=1:BLD=0:ITA=0:UND=0:CLR=-1:ALN=1:DIR=0:ROT=0;LLT=CX=80:CY=14:OX=0:OY=0:HDN=1:BLD=0:ITA=0:UND=0:CLR=-1:ALN=1:DIR=0:ROT=0;LMT=CX={labelLength}:CY=14:OX=0:OY=0:HDN=0:BLD=0:ITA=0:UND=0:CLR=-1:ALN=1:DIR=0:ROT=0;LMB=CX=21:CY=14:OX=0:OY=0:HDN=1:BLD=0:ITA=0:UND=0:CLR=-1:ALN=1:DIR=0:ROT=0;LRT=CX=48:CY=14:OX=0:OY=0:HDN=1:BLD=0:ITA=0:UND=0:CLR=-1:ALN=1:DIR=0:ROT=0;LRB=CX=6:CY=14:OX=0:OY=0:HDN=1:BLD=0:ITA=0:UND=0:CLR=-1:ALN=1:DIR=0:ROT=0;IRHS=;ILHS=;";

				updated = diagramLink.Update();
				if (!updated)
				{
					_sb.AppendLine($"#2 {nameof(CreateReferences)}: foreignKey = {foreignKey.Name} | Error = {diagramLink.GetLastError()}");
					return;
				}

				eaConnector.Update();
				if (!updated)
				{
					_sb.AppendLine($"#3 foreignKey = {foreignKey.Name} | Error = {eaConnector.GetLastError()}");
					return;
				}

				updated = targetTableElement.Update();
				if (!updated)
				{
					_sb.AppendLine($"#4 {nameof(CreateReferences)}: foreignKey = {foreignKey.Name} | Error = {diagramLink.GetLastError()}");
					return;
				}

				updated = sourceTableElement.Update();
				if (!updated)
				{
					_sb.AppendLine($"#5 {nameof(CreateReferences)}: foreignKey = {foreignKey.Name} | Error = {diagramLink.GetLastError()}");
					return;
				}

				updated = eaDiagram.Update();
				if (!updated)
				{
					_sb.AppendLine($"#6 {nameof(CreateReferences)}: foreignKey = {foreignKey.Name} | Error = {diagramLink.GetLastError()}");
					return;
				}

				updated = diagramLink.Update();
				if (!updated)
				{
					_sb.AppendLine($"#7 {nameof(CreateReferences)}: foreignKey = {foreignKey.Name} | Error = {diagramLink.GetLastError()}");
					return;
				}
			}
		}

		private EA.Connector CreateConnector(
			EA.IDualPackage eaPackage,
			EA.IDualElement sourceTableElement,
			EA.IDualElement targetTableElement,
			Envelope.Database.IForeignKey foreignKey,
			bool flipConnector)
		{
			EA.Connector eaConnector = eaPackage.Connectors.AddNew($"{foreignKey.FromColumn.Name} <-> [{foreignKey.ToColumn.Name}]", "Association");
			eaConnector.Direction = "Source -> Destination";
			eaConnector.ClientID = sourceTableElement.ElementID;
			eaConnector.SupplierID = targetTableElement.ElementID;
			eaConnector.Stereotype = "FK";
			eaConnector.StyleEx = $"FKINFO=SRC={foreignKey.Name}:DST={foreignKey.ToColumn.Table.PrimaryKey?.Name}:;";
			var updated = eaConnector.Update();
			if (!updated)
			{
				_sb.AppendLine($"#1 foreignKey = {foreignKey.Name} | Error = {eaConnector.GetLastError()}");
				return null;
			}

			eaConnector.ClientEnd.AllowDuplicates = false;
			eaConnector.ClientEnd.Cardinality = foreignKey.ToColumn.IsNotNull
				? "1..*"
				: "0..*";
			eaConnector.ClientEnd.Containment = "Unspecified";
			eaConnector.ClientEnd.IsChangeable = "none";
			eaConnector.ClientEnd.IsNavigable = flipConnector ? false : true;
			eaConnector.ClientEnd.Navigable = flipConnector ? "Unspecified" : "Navigable";
			eaConnector.ClientEnd.Role = foreignKey.Name;
			updated = eaConnector.ClientEnd.Update();
			if (!updated)
			{
				_sb.AppendLine($"#2 foreignKey = {foreignKey.Name} | Error = {eaConnector.ClientEnd.GetLastError()}");
				return null;
			}

			eaConnector.SupplierEnd.AllowDuplicates = false;
			//eaConnector.SupplierEnd.Aggregation = ??;
			eaConnector.SupplierEnd.Cardinality = foreignKey.FromColumn.IsNotNull
				? "1"
				: "0..1";
			eaConnector.SupplierEnd.Containment = "Unspecified";
			eaConnector.SupplierEnd.IsChangeable = "none";
			eaConnector.SupplierEnd.IsNavigable = flipConnector ? true : false;
			eaConnector.SupplierEnd.Navigable = flipConnector ? "Navigable" : "Unspecified";
			eaConnector.SupplierEnd.Role = foreignKey.ToColumn.Table.PrimaryKey?.Name;
			updated = eaConnector.SupplierEnd.Update();
			if (!updated)
			{
				_sb.AppendLine($"#3 foreignKey = {foreignKey.Name} | Error = {eaConnector.SupplierEnd.GetLastError()}");
				return null;
			}

			eaConnector.Update();
			if (!updated)
			{
				_sb.AppendLine($"#4 foreignKey = {foreignKey.Name} | Error = {eaConnector.GetLastError()}");
				return null;
			}

			return eaConnector;
		}

		#region CreatePackages

		private bool CreatePackages()
		{
			bool created = false;

			EA.Package pgPackage = _eaModelPackage.Packages.AddNew("PostgreSQL Model Structure", "Nothing");

			var updated = pgPackage.Update();
			if (!updated)
			{
				_sb.AppendLine($"#1 schema = PostgreSQL Model Structure | Error = {pgPackage.GetLastError()}");
				return false;
			}

			pgPackage.Element.Stereotype = "DataModel";
			updated = pgPackage.Element.Update();
			if (!updated)
			{
				_sb.AppendLine($"#3 schema = PostgreSQL Model Structure | Error = {pgPackage.GetLastError()}");
				return false;
			}
			updated = pgPackage.Update();
			if (!updated)
			{
				_sb.AppendLine($"#4 schema = PostgreSQL Model Structure | Error = {pgPackage.GetLastError()}");
				return false;
			}

			_basePackagesMap.Add("PostgreSQL Model Structure", pgPackage);

			EA.Package dbPackage = pgPackage.Packages.AddNew(_dbModel.Name, "Nothing");

			updated = dbPackage.Update();
			if (!updated)
			{
				_sb.AppendLine($"#4 schema = {_dbModel.Name} | Error = {dbPackage.GetLastError()}");
				return false;
			}

			dbPackage.Element.Stereotype = "Database";
			updated = dbPackage.Element.Update();
			if (!updated)
			{
				_sb.AppendLine($"#6 schema = {_dbModel.Name} | Error = {dbPackage.GetLastError()}");
				return false;
			}
			updated = dbPackage.Update();
			if (!updated)
			{
				_sb.AppendLine($"#7 schema = {_dbModel.Name} | Error = {dbPackage.GetLastError()}");
				return false;
			}

			_basePackagesMap.Add(_dbModel.Name, dbPackage);

			if (_dbModel?.Schemas == null || !_dbModel.Schemas.Any())
				return created;

			EA.Package tablesPackage = null;
			if (_dbModel.Schemas.Any(x => x.Tables.Any()))
			{
				tablesPackage = dbPackage.Packages.AddNew("Tables_", "Nothing");

				updated = tablesPackage.Update();
				if (!updated)
				{
					_sb.AppendLine($"#11 schema = Tables_ | Error = {tablesPackage.GetLastError()}");
					return false;
				}
			}

			EA.Package viewsPackage = null;
			if (_dbModel.Schemas.Any(x => x.Views.Any()))
			{
				viewsPackage = dbPackage.Packages.AddNew("Views_", "Nothing");

				updated = viewsPackage.Update();
				if (!updated)
				{
					_sb.AppendLine($"#21 schema = Views_ | Error = {viewsPackage.GetLastError()}");
					return false;
				}
			}

			foreach (var schema in _dbModel.Schemas)
			{
				if (schema.Tables.Any())
				{
					var package = CreatePackage(tablesPackage, schema);
					created = package != null || created;

					if (package != null)
						_tableSchemaToPackageMap.Add(schema.Alias, package);
				}

				if (schema.Views.Any())
				{

					var package = CreatePackage(viewsPackage, schema);
					created = package != null || created;

					if (package != null)
						_viewSchemaToPackageMap.Add(schema.Alias, package);
				}
			}

			return created;
		}

		private EA.Package CreatePackage(EA.IDualPackage parentPackage, Envelope.Database.ISchema schema)
		{
			if (string.IsNullOrWhiteSpace(schema.Name))
				return null;

			EA.Package package = parentPackage.Packages.AddNew(schema.Name, "Nothing");

			var updated = package.Update();
			if (!updated)
			{
				_sb.AppendLine($"#1 schema = {schema.Name} | Error = {package.GetLastError()}");
				return null;
			}
			
			package.Element.Alias = schema.Alias;

			updated = package.Update();
			if (!updated)
			{
				_sb.AppendLine($"#2 schema = {schema.Name} | Error = {package.GetLastError()}");
				return null;
			}

			//foreach (var nestedNamespace in schema.NestedNamespaces)
			//	created = CreatePackage(package, nestedNamespace) || created;

			return package;
		}

		#endregion CreatePackages
	}
}
