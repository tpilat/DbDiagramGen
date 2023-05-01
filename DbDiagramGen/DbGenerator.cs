using DbDiagramGen.EAModel;
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

		private Dictionary<string, EA.IDualPackage> _namespaceToPackageMap;
		private Dictionary<string, EA.IDualDiagram> _namespaceToDiagramMap;
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
			_namespaceToPackageMap = new Dictionary<string, EA.IDualPackage> { { "Model", _eaModelPackage } };
			_namespaceToDiagramMap = new Dictionary<string, EA.IDualDiagram>();
			_tableToElementMap = new Dictionary<string, EA.IDualElement>();
			_diagramElements = new Dictionary<string, List<string>>();

			CreatePackages();

			//_model = new Model(_eaRepository);

			foreach (var schema in _dbModel.Schemas)
				CreateDiagram(schema);

			//foreach (var schema in _dbModel.Schemas)
			//	CreateReferences(schema);

			foreach (var eaDiagram in _namespaceToDiagramMap.Values)
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

			foreach (var eaPackage in _namespaceToPackageMap.Values)
				eaPackage.Update();

			return _sb.ToString();
		}

		private bool CreateDiagram(Envelope.Database.ISchema dbSchema)
		{
			bool created = false;

			if (dbSchema.Tables.Any())
			{
				_namespaceToPackageMap.TryGetValue(dbSchema.Name, out var eaPackage);
				if (eaPackage == null)
				{
					_sb.AppendLine($"{nameof(CreateDiagram)}: {nameof(Envelope.Database.ISchema)} {dbSchema.Name} was not found.");
					//throw new InvalidOperationException($"EA.Package {@namespace.FullName} was not found.");
					return false;
				}

				EA.Diagram eaDiagram = eaPackage.Diagrams.AddNew(dbSchema.Name, "Logical");
				eaDiagram.ExtendedStyle = "HideRel=0;ShowTags=0;ShowReqs=0;ShowCons=0;OpParams=1;ShowSN=0;ScalePI=0;PPgs.cx=0;PPgs.cy=0;PSize=9;ShowIcons=1;SuppCN=0;HideProps=0;HideParents=0;UseAlias=0;HideAtts=0;HideOps=0;HideStereo=0;HideEStereo=0;ShowRec=1;ShowRes=0;ShowShape=1;FormName=;";
				eaDiagram.StyleEx = "ExcludeRTF=0;DocAll=0;HideQuals=0;AttPkg=1;ShowTests=0;ShowMaint=0;SuppressFOC=1;MatrixActive=0;SwimlanesActive=1;KanbanActive=0;MatrixLineWidth=1;MatrixLineClr=0;MatrixLocked=0;TConnectorNotation=UML 2.1;TExplicitNavigability=0;AdvancedElementProps=1;AdvancedFeatureProps=1;AdvancedConnectorProps=1;m_bElementClassifier=1;SPT=1;MDGDgm=;STBLDgm=;ShowNotes=0;VisibleAttributeDetail=0;ShowOpRetType=1;SuppressBrackets=0;SuppConnectorLabels=0;PrintPageHeadFoot=0;ShowAsList=0;SuppressedCompartments=;Theme=:119;SIA=1;SaveTag=41AB4851;";
				eaDiagram.Swimlanes = "locked=false;orientation=0;width=0;inbar=false;names=false;color=-1;bold=false;fcol=0;tcol=-1;ofCol=-1;ufCol=-1;hl=1;ufh=0;hh=0;cls=0;bw=0;hli=0;";
				eaDiagram.Update();
				eaPackage.Update();

				_namespaceToDiagramMap.Add(dbSchema.Name, eaDiagram);
				var diagramClasses = new List<string>();

				foreach (var dbTable in dbSchema.Tables)
				{
					CreateTable(eaPackage, eaDiagram, dbTable);
					diagramClasses.Add(dbTable.Name);
				}

				_diagramElements.Add(dbSchema.Name, diagramClasses);

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

			tableElement.Gentype = dbTable.Schema.Model.ProviderType.ToString();

			//TODO
			//if (!string.IsNullOrWhiteSpace(dbTable.Description))
			//	tableElement.Notes = dbTable.Description;

			_tableToElementMap.Add(dbTable.Name, tableElement);

			foreach (var column in dbTable.Columns)
				CreateColumn(tableElement, column);

			tableElement.Update();

			_eaRepository.SaveDiagram(eaDiagram.DiagramID);
			EA.DiagramObject newDiagramObject = eaDiagram.DiagramObjects.AddNew("", "");
			newDiagramObject.ElementID = tableElement.ElementID;
			newDiagramObject.Update();
			eaPackage.Update();
		}

		private void CreateColumn(EA.Element tableElement, Envelope.Database.IColumn column)
		{
			EA.Attribute eaAttribute = tableElement.Attributes.AddNew(column.Name, "");
			eaAttribute.Type = column.DatabaseType;
			//eaAttribute.Notes = column.Description; //TODO
			eaAttribute.IsID = column.IsIdentity;
			eaAttribute.Default = column.DefaultValue;

			eaAttribute.Update();
			tableElement.Update();

			//if (column.IsRequired)
			//{
			//	EA.IDualAttributeTag taggedValue = eaAttribute.TaggedValues.AddNew(nameof(column.IsRequired), "");
			//	taggedValue.Value = column.IsRequired.ToString();
			//	taggedValue.Update();
			//}

			//if (!string.IsNullOrWhiteSpace(column.InversePropertyName))
			//{
			//	EA.IDualAttributeTag taggedValue = eaAttribute.TaggedValues.AddNew(nameof(column.InversePropertyName), "");
			//	taggedValue.Value = column.InversePropertyName.ToString();
			//	taggedValue.Update();
			//}

			eaAttribute.Update();
			tableElement.Update();
		}

		//private void CreateReferences(Envelope.Database.ISchema schema)
		//{
		//	foreach (var dbTable in schema.Tables)
		//		CreateReferences(dbTable);

		//	foreach (var nestedNamespace in schema.NestedNamespaces)
		//		CreateReferences(nestedNamespace);
		//}

		//private void CreateReferences(Envelope.Database.ITable dbTable)
		//{
		//	if (string.IsNullOrWhiteSpace(dbTable.Namespace.FullName))
		//		return;

		//	if (dbTable.IsDataTypeHierarchy())
		//		return;

		//	if (0 < _config.IgnoreNamespaces?.Count)
		//	{
		//		if (_config.IgnoreNamespaces.Any(x => dbTable.Namespace.FullName.StartsWith(x)))
		//			return;
		//	}

		//	if (!_namespaceToPackageMap.TryGetValue(dbTable.Namespace.FullName, out var eaPackage))
		//	{
		//		_sb.AppendLine($"{nameof(CreateReferences)}: #Package# {nameof(Envelope.Database.ISchema)} {dbTable.Namespace.FullName} was not found.");
		//		return;
		//	}

		//	if (!_namespaceToDiagramMap.TryGetValue(dbTable.Namespace.FullName, out var eaDiagram))
		//	{
		//		_sb.AppendLine($"{nameof(CreateReferences)}: #Diagram# {nameof(Envelope.Database.ISchema)} {dbTable.Namespace.FullName} was not found.");
		//		return;
		//	}

		//	if (!_tableToElementMap.TryGetValue(dbTable.FullName, out var currentClassElement))
		//	{
		//		_sb.AppendLine($"{nameof(CreateReferences)}: #Class# {nameof(Envelope.Database.IClass)} {dbTable.FullName} was not found.");
		//		return;
		//	}

		//	if (!_diagramElements.TryGetValue(dbTable.Namespace.FullName, out var currentClassDiagrams))
		//	{
		//		_sb.AppendLine($"{nameof(CreateReferences)}: #SuperClassDiagramElements# {dbTable.Namespace.FullName} was not found.");
		//		return;
		//	}

		//	if (dbTable.SuperClasses != null)
		//	{
		//		foreach (var superClass in dbTable.SuperClasses)
		//		{
		//			if (!_tableToElementMap.TryGetValue(superClass.FullName, out var superClassElement))
		//			{
		//				if (!string.IsNullOrWhiteSpace(superClass.FullName) && !superClass.FullName.StartsWith("%"))
		//					_sb.AppendLine($"{nameof(CreateReferences)}: #SuperClass# {nameof(Envelope.Database.IClass)} {superClass.FullName} was not found.");

		//				continue;
		//			}

		//			//if superClass is not on the same diagram as current class, add to the diagram
		//			if (!currentClassDiagrams.Contains(superClass.FullName))
		//			{
		//				if (!_config.IncludeExternalReferences)
		//					continue;

		//				EA.DiagramObject newDiagramObject = eaDiagram.DiagramObjects.AddNew("", "");
		//				newDiagramObject.ElementID = superClassElement.ElementID;
		//				newDiagramObject.BackgroundColor = 12500670;
		//				newDiagramObject.Update();
		//				currentClassDiagrams.Add(superClass.FullName);
		//			}

		//			EA.Connector eaConnector = eaPackage.Connectors.AddNew("", "Generalization");
		//			eaConnector.SupplierID = superClassElement.ElementID;
		//			eaConnector.ClientID = currentClassElement.ElementID;

		//			//EA.DiagramLink diagramLink = eaDiagram.DiagramLinks.AddNew("", "");
		//			//diagramLink.ConnectorID = eaConnector.ConnectorID;
		//			//diagramLink.Update();

		//			eaConnector.Update();
		//			superClassElement.Update();
		//			currentClassElement.Update();
		//			eaDiagram.Update();
		//		}

		//		foreach (var property in dbTable.Properties)
		//		{
		//			var propertyClasses = property.DeclaredClass.GetAllSuperClasses().Select(x => x.Value).ToList();
		//			propertyClasses.Add(property.DeclaredClass);

		//			if (!(property.Type is Envelope.Database.IClass refClass))
		//				continue;

		//			if (refClass.IsDataType)
		//				continue;

		//			Envelope.Database.IProperty inverseProperty = null;
		//			if (!string.IsNullOrWhiteSpace(property.InversePropertyName))
		//			{
		//				inverseProperty = refClass.GetAllProperties()?.FirstOrDefault(x => propertyClasses.Contains(x.Type) && x.InversePropertyName == property.Name);
		//				if (inverseProperty != null)
		//				{
		//					if (property.InversePropertyName == inverseProperty.Name)
		//					{
		//						inverseProperty.LinkedToReferencedType = true;
		//					}
		//					else
		//					{
		//						//TODO bug???
		//					}
		//				}
		//				else
		//				{
		//					//TODO bug???
		//				}
		//			}

		//			if (!_tableToElementMap.TryGetValue(refClass.FullName, out var refClassElement))
		//			{
		//				_sb.AppendLine($"{nameof(CreateReferences)}: #ReferencedClass# {nameof(Envelope.Database.IClass)} {refClass.FullName} was not found.");
		//				continue;
		//			}

		//			//if refClass is not on the same diagram as current class, add to the diagram
		//			if (!currentClassDiagrams.Contains(refClass.FullName))
		//			{
		//				if (!_config.IncludeExternalReferences)
		//					continue;

		//				EA.DiagramObject newDiagramObject = eaDiagram.DiagramObjects.AddNew("", "");
		//				newDiagramObject.ElementID = refClassElement.ElementID;
		//				newDiagramObject.BackgroundColor = 12500670;
		//				newDiagramObject.Update();
		//				currentClassDiagrams.Add(refClass.FullName);
		//			}

		//			if (!property.LinkedToReferencedType)
		//				CreateConnector(
		//					eaPackage,
		//					currentClassElement,
		//					refClassElement,
		//					property,
		//					inverseProperty);

		//			property.LinkedToReferencedType = true;

		//			//EA.DiagramLink diagramLink = eaDiagram.DiagramLinks.AddNew("", "");
		//			//diagramLink.ConnectorID = eaConnector.ConnectorID;
		//			//diagramLink.Update();

		//			refClassElement.Update();
		//			currentClassElement.Update();
		//			eaDiagram.Update();
		//		}
		//	}
		//}

		//private void CreateConnector(
		//	EA.IDualPackage eaPackage,
		//	EA.IDualElement currentClassElement,
		//	EA.IDualElement refClassElement,
		//	Envelope.Database.IColumn currentColumn,
		//	Envelope.Database.IColumn inverseColumn)
		//{
		//	if (inverseColumn == null)
		//	{
		//		if (currentColumn.Collection.HasValue)
		//		{
		//			EA.Connector eaConnector = eaPackage.Connectors.AddNew($"[{currentColumn.Name}]", "Aggregation");
		//			eaConnector.Direction = "Destination -> Source";
		//			eaConnector.ClientID = currentClassElement.ElementID;
		//			eaConnector.SupplierID = refClassElement.ElementID;
		//			eaConnector.Update();

		//			eaConnector.SupplierEnd.Aggregation = 2;
		//			eaConnector.SupplierEnd.Cardinality = currentColumn.IsRequired
		//				? "1..*"
		//				: "0..*";
		//			eaConnector.SupplierEnd.Containment = "Unspecified";
		//			eaConnector.SupplierEnd.IsChangeable = "none";
		//			eaConnector.SupplierEnd.IsNavigable = false;
		//			eaConnector.SupplierEnd.Navigable = "Unspecified";
		//			eaConnector.SupplierEnd.Update();

		//			eaConnector.Update();
		//		}
		//		else
		//		{
		//			EA.Connector eaConnector = eaPackage.Connectors.AddNew(currentColumn.Name, "Association");
		//			eaConnector.Direction = "Destination -> Source";
		//			eaConnector.ClientID = currentClassElement.ElementID;
		//			eaConnector.SupplierID = refClassElement.ElementID;
		//			eaConnector.Update();

		//			eaConnector.SupplierEnd.Cardinality = currentColumn.IsRequired
		//				? "1"
		//				: "0..1";
		//			eaConnector.SupplierEnd.Containment = "Unspecified";
		//			eaConnector.SupplierEnd.IsChangeable = "none";
		//			eaConnector.SupplierEnd.IsNavigable = false;
		//			eaConnector.SupplierEnd.Navigable = "Unspecified";
		//			eaConnector.SupplierEnd.Update();

		//			eaConnector.Update();
		//		}
		//	}
		//	else
		//	{
		//		if (currentColumn.Type == null
		//			|| inverseColumn.Type == null
		//			|| !currentColumn.IsRelationship
		//			|| !inverseColumn.IsRelationship
		//			|| !currentColumn.Cardinality.HasValue
		//			|| !inverseColumn.Cardinality.HasValue)
		//		{
		//			//TODO bug???
		//			return;
		//		}

		//		var isOneToOne = currentColumn.Cardinality == Envelope.Database.ICardinality.One && inverseColumn.Cardinality == Envelope.Database.ICardinality.One;
		//		var isOneToMany = currentColumn.Cardinality == Envelope.Database.ICardinality.One && inverseColumn.Cardinality == Envelope.Database.ICardinality.Many;
		//		var isManyToMany = currentColumn.Cardinality == Envelope.Database.ICardinality.Many && inverseColumn.Cardinality == Envelope.Database.ICardinality.Many;

		//		if (!isOneToOne && !isOneToMany && !isManyToMany)
		//		{
		//			CreateConnector(
		//				eaPackage,
		//				refClassElement,
		//				currentClassElement,
		//				inverseColumn,
		//				currentColumn);
		//			return;
		//		}

		//		if (isOneToOne)
		//		{
		//			EA.Connector eaConnector = eaPackage.Connectors.AddNew($"{currentColumn.Name} <-> {inverseColumn.Name}", "Association");
		//			eaConnector.Direction = "Destination -> Source";
		//			eaConnector.ClientID = currentClassElement.ElementID;
		//			eaConnector.SupplierID = refClassElement.ElementID;
		//			eaConnector.Update();

		//			eaConnector.ClientEnd.Cardinality = inverseColumn.IsRequired
		//				? "1"
		//				: "0..1";
		//			eaConnector.ClientEnd.Containment = "Unspecified";
		//			eaConnector.ClientEnd.IsChangeable = "none";
		//			eaConnector.ClientEnd.IsNavigable = false;
		//			eaConnector.ClientEnd.Navigable = "Unspecified";
		//			eaConnector.ClientEnd.Update();

		//			eaConnector.SupplierEnd.Cardinality = currentColumn.IsRequired
		//				? "1"
		//				: "0..1";
		//			eaConnector.SupplierEnd.Containment = "Unspecified";
		//			eaConnector.SupplierEnd.IsChangeable = "none";
		//			eaConnector.SupplierEnd.IsNavigable = false;
		//			eaConnector.SupplierEnd.Navigable = "Unspecified";
		//			eaConnector.SupplierEnd.Update();

		//			eaConnector.Update();
		//		}
		//		else if (isOneToMany)
		//		{
		//			EA.Connector eaConnector = eaPackage.Connectors.AddNew($"{currentColumn.Name} <-> [{inverseColumn.Name}]", "Aggregation");
		//			eaConnector.Direction = "Destination -> Source";
		//			eaConnector.ClientID = currentClassElement.ElementID;
		//			eaConnector.SupplierID = refClassElement.ElementID;
		//			eaConnector.Update();

		//			eaConnector.ClientEnd.Cardinality = inverseColumn.IsRequired
		//				? "1..*"
		//				: "0..*";
		//			eaConnector.ClientEnd.Containment = "Unspecified";
		//			eaConnector.ClientEnd.IsChangeable = "none";
		//			eaConnector.ClientEnd.IsNavigable = false;
		//			eaConnector.ClientEnd.Navigable = "Unspecified";
		//			eaConnector.ClientEnd.Update();

		//			eaConnector.SupplierEnd.Aggregation = 2;
		//			eaConnector.SupplierEnd.Cardinality = currentColumn.IsRequired
		//				? "1"
		//				: "0..1";
		//			eaConnector.SupplierEnd.Containment = "Unspecified";
		//			eaConnector.SupplierEnd.IsChangeable = "none";
		//			eaConnector.SupplierEnd.IsNavigable = false;
		//			eaConnector.SupplierEnd.Navigable = "Unspecified";
		//			eaConnector.SupplierEnd.Update();

		//			eaConnector.Update();
		//		}
		//		else //if (isManyToMany)
		//		{
		//			EA.Connector eaConnector = eaPackage.Connectors.AddNew($"[{currentColumn.Name}] <-> [{inverseColumn.Name}]", "Association");
		//			eaConnector.Direction = "Destination -> Source";
		//			eaConnector.ClientID = currentClassElement.ElementID;
		//			eaConnector.SupplierID = refClassElement.ElementID;
		//			eaConnector.Update();

		//			eaConnector.ClientEnd.Cardinality = inverseColumn.IsRequired
		//				? "1..*"
		//				: "0..*";
		//			eaConnector.ClientEnd.Containment = "Unspecified";
		//			eaConnector.ClientEnd.IsChangeable = "none";
		//			eaConnector.ClientEnd.IsNavigable = false;
		//			eaConnector.ClientEnd.Navigable = "Unspecified";
		//			eaConnector.ClientEnd.Update();

		//			eaConnector.SupplierEnd.Cardinality = currentColumn.IsRequired
		//				? "1..*"
		//				: "0..*";
		//			eaConnector.SupplierEnd.Containment = "Unspecified";
		//			eaConnector.SupplierEnd.IsChangeable = "none";
		//			eaConnector.SupplierEnd.IsNavigable = false;
		//			eaConnector.SupplierEnd.Navigable = "Unspecified";
		//			eaConnector.SupplierEnd.Update();

		//			eaConnector.Update();
		//		}
		//	}
		//}

		#region CreatePackages

		private bool CreatePackages()
		{
			bool created = false;

			if (_dbModel?.Schemas == null || !_dbModel.Schemas.Any())
				return created;

			foreach (var schema in _dbModel.Schemas)
				created = CreatePackage(_eaModelPackage, schema) || created;

			return created;
		}

		private bool CreatePackage(EA.IDualPackage parentPackage, Envelope.Database.ISchema schema)
		{
			if (string.IsNullOrWhiteSpace(schema.Name))
				return false;

			EA.Package package = parentPackage.Packages.AddNew(schema.Name, "Nothing");
			_namespaceToPackageMap.Add(schema.Name, package);
			package.Update();

			//foreach (var nestedNamespace in schema.NestedNamespaces)
			//	created = CreatePackage(package, nestedNamespace) || created;

			return true;
		}

		#endregion CreatePackages
	}
}
