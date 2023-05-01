using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IrisExportParser
{
	public class Parser
	{
		private readonly Dictionary<string, IrisClassWrapper> _irisClassesName;
		private readonly Dictionary<Class, IrisClassWrapper> _irisClasses;

		private readonly Dictionary<string, ClassModel.Namespace> _classModelNamespaces;

		public IrisParserConfig Config { get; }

		private readonly StringBuilder _sb;
		private readonly StringBuilder _sbNamespace;
		private ClassModel.Model _model;
		private ClassModel.Namespace _defaultNamespace;

		public Parser(IrisParserConfig config)
		{
			Config = config ?? new IrisParserConfig();
			_irisClassesName = new Dictionary<string, IrisClassWrapper>();
			_irisClasses = new Dictionary<Class, IrisClassWrapper>();

			_classModelNamespaces = new Dictionary<string, ClassModel.Namespace>();

			_sb = new StringBuilder();
			_sbNamespace = new StringBuilder();
		}

		public ClassModel.Model Parse(Stream stream, out string errors)
		{
			_model = new ClassModel.Model();
			_irisClassesName.Clear();
			_irisClasses.Clear();
			_classModelNamespaces.Clear();
			_sb.Clear();

			_defaultNamespace = CreateNamespaces("", out _);

			var serializer = new XmlSerializer(typeof(Export));
			var irisExport = (Export)serializer.Deserialize(stream);

			foreach (var item in irisExport.Items)
			{
				if (item is Class irisClass)
				{
					if (_irisClassesName.ContainsKey(irisClass.name))
						continue;

					var @namespace = CreateNamespaces(irisClass.name, out string className);

					if (0 < Config.DataTypes?.Count
						&& Config.DataTypes.Any(x => irisClass.name.StartsWith(x)))
						continue;

					var irisClassWrapper = new IrisClassWrapper(irisClass, @namespace.FullName, className);
					ParseIrisClass(irisClassWrapper, @namespace);
				}
			}

			SetReferenceClasses();

			SetDataTypeClasses();

			errors = _sb.ToString();
			if (string.IsNullOrWhiteSpace(errors))
				errors = null;

			return _model;
		}

		private void ParseIrisClass(IrisClassWrapper wrapper, ClassModel.Namespace @namespace)
		{
			_irisClassesName.Add(wrapper.FullName, wrapper);
			_irisClasses.Add(wrapper.IrisClass, wrapper);

			wrapper.Class = new ClassModel.Class(false)
			{
				Name = wrapper.Name,
				Language = "ObjectScript",
				Visibility = ClassModel.Visibility.Public
			};
			@namespace.AddClass(wrapper.Class);

			for (int i = 0; i < wrapper.IrisClass.ItemsElementName.Length; i++)
			{
				var item = wrapper.IrisClass.Items[i];
				switch (wrapper.IrisClass.ItemsElementName[i])
				{
					case ItemsChoiceType19.Abstract:
						if (item is bool isAbstract)
							wrapper.Class.IsAbstract = isAbstract;
						break;
					case ItemsChoiceType19.ClassDefinitionError:
						break;
					case ItemsChoiceType19.ClassType:
						break;
					case ItemsChoiceType19.ClientDataType:
						break;
					case ItemsChoiceType19.ClientName:
						break;
					case ItemsChoiceType19.CompileAfter:
						break;
					case ItemsChoiceType19.ConstraintClass:
						break;
					case ItemsChoiceType19.Copyright:
						break;
					case ItemsChoiceType19.DdlAllowed:
						break;
					case ItemsChoiceType19.DependsOn:
						break;
					case ItemsChoiceType19.Deployed:
						break;
					case ItemsChoiceType19.Deprecated:
						if (item is bool isDeprecated)
							wrapper.Class.IsDeprecated = isDeprecated;
						break;
					case ItemsChoiceType19.Description:
						if (item is string description)
							wrapper.Class.Description = description;
						break;
					case ItemsChoiceType19.Dynamic:
						break;
					case ItemsChoiceType19.EmbeddedClass:
						break;
					case ItemsChoiceType19.Final:
						break;
					case ItemsChoiceType19.ForeignKey:
						break;
					case ItemsChoiceType19.GeneratedBy:
						break;
					case ItemsChoiceType19.Hidden:
						break;
					case ItemsChoiceType19.Import:
						break;
					case ItemsChoiceType19.IncludeCode:
						break;
					case ItemsChoiceType19.IncludeGenerator:
						break;
					case ItemsChoiceType19.Index:
						break;
					case ItemsChoiceType19.IndexClass:
						break;
					case ItemsChoiceType19.Inheritance:
						break;
					case ItemsChoiceType19.Language:
						break;
					case ItemsChoiceType19.LegacyInstanceContext:
						break;
					case ItemsChoiceType19.MemberSuper:
						break;
					case ItemsChoiceType19.Method:
						break;
					case ItemsChoiceType19.Modified:
						break;
					case ItemsChoiceType19.NoContext:
						break;
					case ItemsChoiceType19.NoExtent:
						break;
					case ItemsChoiceType19.OdbcType:
						break;
					case ItemsChoiceType19.Owner:
						break;
					case ItemsChoiceType19.Parameter:
						break;
					case ItemsChoiceType19.ProcedureBlock:
						break;
					case ItemsChoiceType19.Projection:
						break;
					case ItemsChoiceType19.ProjectionClass:
						break;
					case ItemsChoiceType19.Property:
						if (item is ClassProperty irisProperty)
							ParseProperty(irisProperty, wrapper.IrisProperties, wrapper.Class);
						break;
					case ItemsChoiceType19.PropertyClass:
						break;
					case ItemsChoiceType19.Query:
						break;
					case ItemsChoiceType19.QueryClass:
						break;
					case ItemsChoiceType19.ServerOnly:
						break;
					case ItemsChoiceType19.Sharded:
						break;
					case ItemsChoiceType19.SoapBindingStyle:
						break;
					case ItemsChoiceType19.SoapBodyUse:
						break;
					case ItemsChoiceType19.SqlCategory:
						break;
					case ItemsChoiceType19.SqlRoutinePrefix:
						break;
					case ItemsChoiceType19.SqlRowIdName:
						break;
					case ItemsChoiceType19.SqlRowIdPrivate:
						break;
					case ItemsChoiceType19.SqlTableName:
						break;
					case ItemsChoiceType19.Storage:
						break;
					case ItemsChoiceType19.StorageStrategy:
						break;
					case ItemsChoiceType19.Super:
						if (item is string super)
							wrapper.SuperClasses = super;
						break;
					case ItemsChoiceType19.System:
						break;
					case ItemsChoiceType19.TimeChanged:
						break;
					case ItemsChoiceType19.TimeCreated:
						break;
					case ItemsChoiceType19.Trigger:
						break;
					case ItemsChoiceType19.TriggerClass:
						break;
					case ItemsChoiceType19.UDLText:
						break;
					case ItemsChoiceType19.ViewQuery:
						break;
					case ItemsChoiceType19.XData:
						break;
					default:
						break;
				}
			}
		}

		private List<string> SplitNameSpace(string name)
		{
			var split = name.Split(new string[] { "." }, System.StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
			if (split.Count == 1)
			{
				return new List<string> { "", split[0] };
			}
			else
			{
				return split;
			}
		}

		private ClassModel.Namespace CreateNamespaces(string name, out string className)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				var @namespace = new ClassModel.Namespace { Name = "" };
				_model.AddNamespace(@namespace);
				_classModelNamespaces.Add(@namespace.FullName, @namespace);
				className = "";
				return @namespace;
			}

			var namespaceParts = SplitNameSpace(name);

			ClassModel.Namespace currentNamespace = null;
			_sbNamespace.Clear();
			var first = true;
			var index = 1;
			foreach (var part in namespaceParts)
			{
				if (index == namespaceParts.Count)
					break;

				index++;

				if (!first)
					_sbNamespace.Append(".");

				_sbNamespace.Append(part);
				var currentFullName = _sbNamespace.ToString();

				if (_classModelNamespaces.TryGetValue(currentFullName, out var @namespace))
				{
					currentNamespace = @namespace;
				}
				else
				{
					var previousNamespace = currentNamespace;
					currentNamespace = new ClassModel.Namespace { Name = part };

					if (previousNamespace != null)
						previousNamespace.AddNestedNamespace(currentNamespace);

					_classModelNamespaces.Add(currentNamespace.FullName, currentNamespace);

					if (first)
						_model.AddNamespace(currentNamespace);
				}

				first = false;
			}

			className = namespaceParts.LastOrDefault();
			return currentNamespace;
		}

		private void ParseProperty(ClassProperty irisProperty, Dictionary<string, ClassProperty> allIrisProperties, ClassModel.Class @class)
		{
			if (allIrisProperties.ContainsKey(irisProperty.name))
				return;

			allIrisProperties.Add(irisProperty.name, irisProperty);

			var result = new ClassModel.Property { Name = irisProperty.name };
			@class.AddProperty(result);

			for (int i = 0; i < irisProperty.ItemsElementName.Length; i++)
			{
				var item = irisProperty.Items[i];
				switch (irisProperty.ItemsElementName[i])
				{
					case ItemsChoiceType6.Aliases:
						break;
					case ItemsChoiceType6.Calculated:
						if (item is bool isCalculated)
							result.IsCalculated = isCalculated;
						break;
					case ItemsChoiceType6.Cardinality:
						if (item is ClassPropertyCardinality classPropertyCardinality)
						{
							switch (classPropertyCardinality)
							{
								case ClassPropertyCardinality.one:
								case ClassPropertyCardinality.ONE:
								case ClassPropertyCardinality.One:
								case ClassPropertyCardinality.parent:
								case ClassPropertyCardinality.PARENT:
								case ClassPropertyCardinality.Parent:
									result.Cardinality = ClassModel.Cardinality.One;
									break;
								case ClassPropertyCardinality.many:
								case ClassPropertyCardinality.MANY:
								case ClassPropertyCardinality.Many:
								case ClassPropertyCardinality.children:
								case ClassPropertyCardinality.CHILDREN:
								case ClassPropertyCardinality.Children:
									result.Cardinality = ClassModel.Cardinality.Many;
									break;
								default:
									result.Cardinality = null;
									break;
							}
						}
						break;
					case ItemsChoiceType6.ClientName:
						break;
					case ItemsChoiceType6.Collection:
						if (item is ClassPropertyCollection classPropertyCollection)
						{
							switch (classPropertyCollection)
							{
								case ClassPropertyCollection.array:
								case ClassPropertyCollection.ARRAY:
								case ClassPropertyCollection.Array:
									result.Collection = ClassModel.CollectionEnum.Array;
									break;
								case ClassPropertyCollection.list:
								case ClassPropertyCollection.LIST:
								case ClassPropertyCollection.List:
									result.Collection = ClassModel.CollectionEnum.List;
									break;
								case ClassPropertyCollection.binarystream:
								case ClassPropertyCollection.BINARYSTREAM:
								case ClassPropertyCollection.Binarystream:
									result.Collection = ClassModel.CollectionEnum.BinaryStream;
									break;
								case ClassPropertyCollection.characterstream:
								case ClassPropertyCollection.CHARACTERSTREAM:
								case ClassPropertyCollection.Characterstream:
									result.Collection = ClassModel.CollectionEnum.CharacterStream;
									break;
								default:
									result.Collection = null;
									break;
							}
						}
						break;
					case ItemsChoiceType6.Deprecated:
						if (item is bool isDeprecated)
							result.IsDeprecated = isDeprecated;
						break;
					case ItemsChoiceType6.Description:
						if (item is string description)
							result.Description = description;
						break;
					case ItemsChoiceType6.Final:
						break;
					case ItemsChoiceType6.Identity:
						if (item is bool identity)
							result.IsIdentity = identity;
						break;
					case ItemsChoiceType6.InitialExpression:
						if (item is string initialExpression)
							result.InitialExpression = initialExpression;
						break;
					case ItemsChoiceType6.Internal:
						break;
					case ItemsChoiceType6.Inverse:
						if (item is string inverse)
							result.InversePropertyName = inverse;
						break;
					case ItemsChoiceType6.MultiDimensional:
						if (item is bool isMultiDimensional)
							result.IsMultiDimensional = isMultiDimensional;
						break;
					case ItemsChoiceType6.NoModBit:
						break;
					case ItemsChoiceType6.NotInheritable:
						break;
					case ItemsChoiceType6.OnDelete:
						break;
					case ItemsChoiceType6.Parameter:
						break;
					case ItemsChoiceType6.Private:
						if (item is bool isPrivate)
							result.Visibility = isPrivate
								? ClassModel.Visibility.Private
								: ClassModel.Visibility.Public;
						break;
					case ItemsChoiceType6.ReadOnly:
						if (item is bool isReadOnly)
							result.IsReadOnly = isReadOnly;
						break;
					case ItemsChoiceType6.Relationship:
						if (item is bool isRelationship)
							result.IsRelationship = isRelationship;
						break;
					case ItemsChoiceType6.Required:
						if (item is bool isRequired)
							result.IsRequired = isRequired;
						break;
					case ItemsChoiceType6.ServerOnly:
						break;
					case ItemsChoiceType6.SqlCollation:
						break;
					case ItemsChoiceType6.SqlColumnNumber:
						break;
					case ItemsChoiceType6.SqlComputeCode:
						break;
					case ItemsChoiceType6.SqlComputeOnChange:
						break;
					case ItemsChoiceType6.SqlComputed:
						break;
					case ItemsChoiceType6.SqlFieldName:
						break;
					case ItemsChoiceType6.SqlListDelimiter:
						break;
					case ItemsChoiceType6.SqlListType:
						break;
					case ItemsChoiceType6.Transient:
						if (item is bool transient)
							result.IsTransient = transient;
						break;
					case ItemsChoiceType6.Type:
						if (item is string type)
							result.TypeFullName = type;
						break;
					case ItemsChoiceType6.UDLText:
						break;
					default:
						break;
				}
			}
		}

		private void SetReferenceClasses()
		{
			var dataTypes = new Dictionary<string, ClassModel.Class>();

			foreach (var wrapper in _irisClasses.Values)
			{
				if (!string.IsNullOrWhiteSpace(wrapper.SuperClasses))
					SetSuperClasses(wrapper);

				//Set Class.Persistence
				if (0 < Config.PersistentClasses?.Count)
				{
					if (Config.PersistentClasses.Any(x => wrapper.Class.FullName.StartsWith(x)))
					{
						wrapper.Class.Persistence = ClassModel.Persistence.Persistent;
						foreach (var child in wrapper.Class.ChildClasses)
							child.Persistence = ClassModel.Persistence.Persistent;
					}

					if (!wrapper.Class.Persistence.HasValue
						&& wrapper.Class.GetAllSuperClasses().Select(x => x.Value).Any(superClass => Config.PersistentClasses.Any(x => superClass.FullName.StartsWith(x))))
					{
						wrapper.Class.Persistence = ClassModel.Persistence.Persistent;
						foreach (var child in wrapper.Class.ChildClasses)
							child.Persistence = ClassModel.Persistence.Persistent;
					}
				}
			}

			foreach (var wrapper in _irisClasses.Values)
			{
				foreach (var property in wrapper.Class.Properties.Where(x => !string.IsNullOrWhiteSpace(x.TypeFullName)))
				{
					if (_irisClassesName.TryGetValue(property.TypeFullName, out var referencedClassWrapper))
					{
						property.Type = referencedClassWrapper.Class;
					}
					else if (property.TypeFullName.StartsWith("%"))
					{
						//do nothing
					}
					else if (0 < Config.DataTypes?.Count && Config.DataTypes.Any(x => property.TypeFullName.StartsWith(x)))
					{
						//do nothing
					}
					//else if (!dataTypes.ContainsKey(property.TypeFullName))
					//{
					//	var @namespace = CreateNamespaces(property.TypeFullName, out string className);

					//	var dataType = new ClassModel.DataType { Name = className };
					//	@namespace.AddDataType(dataType);

					//	dataTypes.Add(property.TypeFullName, dataType);
					//	_model.AddDataType(dataType);
					//}
					else
					{
						_sb.AppendLine($"Class {wrapper.FullName} has property {property.Name}, property type is {property.TypeFullName}, but the referenced class was not found in export.");
						_sb.AppendLine();
					}
				}
			}
		}

		private void SetSuperClasses(IrisClassWrapper wrapper)
		{
			var superClasses = wrapper.SuperClasses.Split(new string[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
			foreach (var superClassName in superClasses.Select(x => x.Trim()))
			{
				if (_irisClassesName.TryGetValue(superClassName, out var superClassWrapper))
				{
					wrapper.Class.AddSuperClass(superClassWrapper.Class);
				}
				else if (0 < Config.DataTypes?.Count && Config.DataTypes.Any(x => superClassName.StartsWith(x)))
				{
					//do nothing
				}
				else if (superClassName.StartsWith("%"))
				{
					var @class = new ClassModel.Class(false)
					{
						Name = superClassName,
						Language = "ObjectScript"
					};
					_defaultNamespace.AddClass(@class);
					wrapper.Class.AddSuperClass(@class);
					
					//_irisClassesName.Add(superClass, @class);
				}
				else //if (!superClass.StartsWith("%"))
				{
					_sb.AppendLine($"Class {wrapper.FullName} has super class {superClassName}, but the super class was not found in export.");
					_sb.AppendLine();
				}
			}
		}

		private void SetDataTypeClasses()
		{
			if (Config.DataTypes == null || Config.DataTypes.Count == 0)
				return;

			foreach (var @class in _model.GetAllClasses())
			{
				if (Config.DataTypes.Any(x => @class.FullName.StartsWith(x)))
				{
					@class.IsDataType = true;
					continue;
				}

				var superClasses = @class.GetAllSuperClasses().Select(x => x.Value);
				foreach (var superClass in superClasses)
				{
					if (Config.DataTypes.Any(x => superClass.FullName.StartsWith(x)))
					{
						@class.IsDataType = true;
						break;
					}
				}
			}
		}
	}
}
