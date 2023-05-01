using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EARepository : IEAObject
	{
		public global::EA.IDualRepository WrappedRepository { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => WrappedRepository.ProjectGUID;
		public List<EADataType> DataTypes { get; set; }

		public EA.Package WrappedCurrentEAPackage { get; set; }
		public EAPackage CurrentEAPackage { get; set; }

		public Dictionary<global::EA.IDualDatatype, EADataType> DataTypesDict { get; }
		public Dictionary<string, EAAttribute> Attributes { get; }
		public Dictionary<string, EAConnector> Connectors { get; }
		public Dictionary<int, EAConnector> ConnectorsById { get; }
		public Dictionary<global::EA.IDualConnectorEnd, EAConnectorEnd> ConnectorEnds { get; }
		public Dictionary<global::EA.IDualConstraint, EAConstraint> Constraints { get; }
		public Dictionary<string, EADiagram> Diagrams { get; }
		public Dictionary<global::EA.IDualDiagramLink, EADiagramLink> DiagramLinks { get; }
		public Dictionary<global::EA.IDualDiagramObject, EADiagramObject> DiagramObjects { get; }
		public Dictionary<string, EAElement> Elements { get; }
		public Dictionary<int, EAElement> ElementsById { get; }
		public Dictionary<string, EAPackage> Packages { get; }
		public Dictionary<global::EA.IDualTaggedValue, EATaggedValue> TaggedValues { get; }
		public Dictionary<global::EA.IDualAttributeTag, EAAttributeTag> AttributeTags { get; }

		public EARepository(global::EA.IDualRepository repository)
		{
			WrappedRepository = repository;
			Repository = this;

			DataTypes = new List<EADataType>();

			DataTypesDict = new Dictionary<EA.IDualDatatype, EADataType>();
			Attributes = new Dictionary<string, EAAttribute>();
			Connectors = new Dictionary<string, EAConnector>();
			ConnectorsById = new Dictionary<int, EAConnector>();
			ConnectorEnds = new Dictionary<global::EA.IDualConnectorEnd, EAConnectorEnd>();
			Constraints = new Dictionary<global::EA.IDualConstraint, EAConstraint>();
			Diagrams = new Dictionary<string, EADiagram>();
			DiagramLinks = new Dictionary<global::EA.IDualDiagramLink, EADiagramLink>();
			DiagramObjects = new Dictionary<global::EA.IDualDiagramObject, EADiagramObject>();
			Elements = new Dictionary<string, EAElement>();
			ElementsById = new Dictionary<int, EAElement>();
			Packages = new Dictionary<string, EAPackage>();
			TaggedValues = new Dictionary<global::EA.IDualTaggedValue, EATaggedValue>();
			AttributeTags = new Dictionary<EA.IDualAttributeTag, EAAttributeTag>();

			WrappedCurrentEAPackage = GetCurrentModelPackage(WrappedRepository);
			if (WrappedCurrentEAPackage == null)
				throw new InvalidOperationException("No model package found.");
		}

		public void Build()
		{
			if (WrappedRepository.Datatypes != null)
				foreach (global::EA.IDualDatatype datatype in WrappedRepository.Datatypes)
					DataTypes.Add(AddOrGetEADataType(datatype));

			CurrentEAPackage = AddOrGetEAPackage(WrappedCurrentEAPackage);
			CurrentEAPackage.SetReferences();
		}

		public void SetReferences()
		{
		}

		public static EA.Package GetCurrentModelPackage(EA.IDualRepository repository)
		{
			EA.Package selectedEAPackage = GetCurrentSelectedPackage(repository);
			return GetCurrentModelPackage(repository, selectedEAPackage);
		}

		public static EA.Package GetCurrentSelectedPackage(EA.IDualRepository repository)
		{
			EA.Package selectedEAPackage = repository.GetTreeSelectedPackage();
			return selectedEAPackage;
		}

		public static EA.Package GetCurrentModelPackage(EA.IDualRepository repository, EA.Package package)
		{
			if (package == null)
				return null;

			if (package.ParentID == 0)
				return package;

			return GetCurrentModelPackage(repository, repository.GetPackageByID(package.ParentID));
		}

		public EADataType AddOrGetEADataType(global::EA.IDualDatatype dataType)
		{
			if (!DataTypesDict.TryGetValue(dataType, out var eaDataType))
			{
				eaDataType = new EADataType(dataType, this);
				DataTypesDict.Add(dataType, eaDataType);
				eaDataType.Build();
			}

			return eaDataType;
		}

		public EAAttribute AddOrGetEAAttribute(global::EA.IDualAttribute attribute)
		{
			if (!Attributes.TryGetValue(attribute.AttributeGUID, out var eaAttribute))
			{
				eaAttribute = new EAAttribute(attribute, this);
				Attributes.Add(attribute.AttributeGUID, eaAttribute);
				eaAttribute.Build();
			}

			return eaAttribute;
		}

		public EAConnector AddOrGetEAConnector(global::EA.IDualConnector connector)
		{
			if (!Connectors.TryGetValue(connector.ConnectorGUID, out var eaConnector))
			{
				eaConnector = new EAConnector(connector, this);
				Connectors.Add(connector.ConnectorGUID, eaConnector);
				ConnectorsById.Add(connector.ConnectorID, eaConnector);
				eaConnector.Build();
			}

			return eaConnector;
		}

		public EAConnectorEnd AddOrGetEAConnectorEnd(global::EA.IDualConnectorEnd connectorEnd)
		{
			if (!ConnectorEnds.TryGetValue(connectorEnd, out var eaConnectorEnd))
			{
				eaConnectorEnd = new EAConnectorEnd(connectorEnd, this);
				ConnectorEnds.Add(connectorEnd, eaConnectorEnd);
				eaConnectorEnd.Build();
			}

			return eaConnectorEnd;
		}

		public EAConstraint AddOrGetEAConstraint(global::EA.IDualConstraint constraint)
		{
			if (!Constraints.TryGetValue(constraint, out var eaConstraint))
			{
				eaConstraint = new EAConstraint(constraint, this);
				Constraints.Add(constraint, eaConstraint);
				eaConstraint.Build();
			}

			return eaConstraint;
		}

		public EADiagram AddOrGetEADiagram(global::EA.IDualDiagram diagram)
		{
			if (!Diagrams.TryGetValue(diagram.DiagramGUID, out var eaDiagram))
			{
				eaDiagram = new EADiagram(diagram, this);
				Diagrams.Add(diagram.DiagramGUID, eaDiagram);
				eaDiagram.Build();
			}

			return eaDiagram;
		}

		public EADiagramLink AddOrGetEADiagramLink(global::EA.IDualDiagramLink diagramLink)
		{
			if (!DiagramLinks.TryGetValue(diagramLink, out var eaDiagramLink))
			{
				eaDiagramLink = new EADiagramLink(diagramLink, this);
				DiagramLinks.Add(diagramLink, eaDiagramLink);
				eaDiagramLink.Build();
			}

			return eaDiagramLink;
		}

		public EADiagramObject AddOrGetEADiagramObject(global::EA.IDualDiagramObject diagramObject)
		{
			if (!DiagramObjects.TryGetValue(diagramObject, out var eaDiagramObject))
			{
				eaDiagramObject = new EADiagramObject(diagramObject, this);
				DiagramObjects.Add(diagramObject, eaDiagramObject);
				eaDiagramObject.Build();
			}

			return eaDiagramObject;
		}

		public EAElement AddOrGetEAElement(global::EA.IDualElement element)
		{
			if (!Elements.TryGetValue(element.ElementGUID, out var eaElement))
			{
				eaElement = new EAElement(element, this);
				Elements.Add(element.ElementGUID, eaElement);
				ElementsById.Add(element.ElementID, eaElement);
				eaElement.Build();
			}

			return eaElement;
		}

		public EAPackage AddOrGetEAPackage(global::EA.IDualPackage package)
		{
			if (!Packages.TryGetValue(package.PackageGUID, out var eaPackage))
			{
				eaPackage = new EAPackage(package, this);
				Packages.Add(package.PackageGUID, eaPackage);
				eaPackage.Build();
			}

			return eaPackage;
		}

		public EATaggedValue AddOrGetEATaggedValue(global::EA.IDualTaggedValue taggedValue)
		{
			if (!TaggedValues.TryGetValue(taggedValue, out var eaTaggedValue))
			{
				eaTaggedValue = new EATaggedValue(taggedValue, this);
				TaggedValues.Add(taggedValue, eaTaggedValue);
				eaTaggedValue.Build();
			}

			return eaTaggedValue;
		}

		public EAAttributeTag AddOrGetEAAttributeTag(global::EA.IDualAttributeTag attributeTag)
		{
			if (!AttributeTags.TryGetValue(attributeTag, out var eaAttributeTag))
			{
				eaAttributeTag = new EAAttributeTag(attributeTag, this);
				AttributeTags.Add(attributeTag, eaAttributeTag);
				eaAttributeTag.Build();
			}

			return eaAttributeTag;
		}

		public override string ToString()
			=> $"{WrappedRepository.ConnectionString}";
	}
}
