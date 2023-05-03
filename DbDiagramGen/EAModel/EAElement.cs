using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EAElement : IEAObject
	{
		public global::EA.IDualElement WrappedElement { get; }
		public EARepository Repository { get; }
		public int ID => WrappedElement.ElementID;
		public string GUID => WrappedElement.ElementGUID;

		public List<EAAttribute> Attributes { get; set; }
		public List<EAConstraint> Constraints { get; set; }
		public List<EATaggedValue> TaggedValues { get; set; }
		public List<EAConnector> Connectors { get; set; }
		public List<EAElement> Elements { get; set; }
		public List<EADiagram> Diagrams { get; set; }
		public List<EATaggedValue> TaggedValuesEx { get; set; }
		public List<EAAttribute> AttributesEx { get; set; }
		public List<EAConstraint> ConstraintsEx { get; set; }

		public EAPackage Package { get; set; }
		public EAElement ParentElement { get; set; }

		public EAElement(global::EA.IDualElement element, EARepository repository)
		{
			WrappedElement = element;
			Repository = repository;

			Attributes = new List<EAAttribute>();
			Constraints = new List<EAConstraint>();
			TaggedValues = new List<EATaggedValue>();
			Connectors = new List<EAConnector>();
			Elements = new List<EAElement>();
			Diagrams = new List<EADiagram>();
			TaggedValuesEx = new List<EATaggedValue>();
			AttributesEx = new List<EAAttribute>();
			ConstraintsEx = new List<EAConstraint>();
		}

		private bool _initialized;
		public void Build()
		{
			if (_initialized)
				return;

			_initialized = true;

			if (WrappedElement.Attributes != null)
				foreach (global::EA.IDualAttribute attribute in WrappedElement.Attributes)
					Attributes.Add(Repository.AddOrGetEAAttribute(attribute));

			if (WrappedElement.Constraints != null)
				foreach (global::EA.IDualConstraint constraint in WrappedElement.Constraints)
					Constraints.Add(Repository.AddOrGetEAConstraint(constraint));

			if (WrappedElement.TaggedValues != null)
				foreach (global::EA.IDualTaggedValue taggedValue in WrappedElement.TaggedValues)
					TaggedValues.Add(Repository.AddOrGetEATaggedValue(taggedValue));

			if (WrappedElement.Connectors != null)
				foreach (global::EA.IDualConnector connector in WrappedElement.Connectors)
					Connectors.Add(Repository.AddOrGetEAConnector(connector));

			if (WrappedElement.Elements != null)
				foreach (global::EA.IDualElement element in WrappedElement.Elements)
					Elements.Add(Repository.AddOrGetEAElement(element));

			if (WrappedElement.Diagrams != null)
				foreach (global::EA.IDualDiagram diagram in WrappedElement.Diagrams)
					Diagrams.Add(Repository.AddOrGetEADiagram(diagram));

			if (WrappedElement.TaggedValuesEx != null)
				foreach (global::EA.IDualTaggedValue taggedValueEx in WrappedElement.TaggedValuesEx)
					TaggedValuesEx.Add(Repository.AddOrGetEATaggedValue(taggedValueEx));

			if (WrappedElement.AttributesEx != null)
				foreach (global::EA.IDualAttribute attributeEx in WrappedElement.AttributesEx)
					AttributesEx.Add(Repository.AddOrGetEAAttribute(attributeEx));

			if (WrappedElement.ConstraintsEx != null)
				foreach (global::EA.IDualConstraint constraintEx in WrappedElement.ConstraintsEx)
					ConstraintsEx.Add(Repository.AddOrGetEAConstraint(constraintEx));

			if (WrappedElement.Methods != null)
				foreach (global::EA.IDualMethod method in WrappedElement.Methods)
				{
					var stereotype = method.Stereotype;
					if (stereotype == "PK")
					{
						var count = 0;
						if (method.Parameters != null)
							foreach (global::EA.IDualParameter parameter in method.Parameters)
								count++;

						if (1 < count)
						{
							Console.WriteLine();
						}
					}
					else if (stereotype == "index")
					{
						var count = 0;
						if (method.Parameters != null)
							foreach (global::EA.IDualParameter parameter in method.Parameters)
								count++;

						if (1 < count)
						{
							Console.WriteLine();
						}
					}
					else if (stereotype == "unique")
					{
						var count = 0;
						if (method.Parameters != null)
							foreach (global::EA.IDualParameter parameter in method.Parameters)
								count++;

						if (1 < count)
						{
							Console.WriteLine();
						}
					}
					else if (stereotype == "FK")
					{
						var count = 0;
						if (method.Parameters != null)
							foreach (global::EA.IDualParameter parameter in method.Parameters)
								count++;

						if (1 < count)
						{
							Console.WriteLine();
						}
					}
					else
					{
						var count = 0;
						if (method.Parameters != null)
							foreach (global::EA.IDualParameter parameter in method.Parameters)
								count++;

						if (1 < count)
						{
							Console.WriteLine();
						}
					}
				}

			if (WrappedElement.CustomProperties != null)
				foreach (global::EA.ICustomProperty customProperty in WrappedElement.CustomProperties)
					Console.WriteLine(customProperty);

			if (WrappedElement.Properties != null)
				foreach (global::EA.Property property in WrappedElement.Properties)
					Console.WriteLine(property);
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			foreach (var attribute in Attributes)
			{
				if (attribute.Element != null && attribute.Element != this)
					throw new InvalidOperationException($"Invalid {nameof(attribute)}.{nameof(attribute.Element)}");

				attribute.Element = this;
				attribute.SetReferences();
			}

			foreach (var constraint in Constraints)
			{
				if (constraint.Element != null && constraint.Element != this)
					throw new InvalidOperationException($"Invalid {nameof(constraint)}.{nameof(constraint.Element)}");

				constraint.Element = this;
				constraint.SetReferences();
			}

			foreach (var taggedValue in TaggedValues)
			{
				if (taggedValue.Element != null && taggedValue.Element != this)
					throw new InvalidOperationException($"Invalid {nameof(taggedValue)}.{nameof(taggedValue.Element)}");

				taggedValue.Element = this;
				taggedValue.SetReferences();
			}

			foreach (var connector in Connectors)
			{
				//if (!connector.Elements.Contains(this))
				//	connector.Elements.Add(this);

				connector.SetReferences();
			}

			foreach (var elements in Elements)
			{
				if (elements.ParentElement != null && elements.ParentElement != this)
					throw new InvalidOperationException($"Invalid {nameof(elements)}.{nameof(elements.ParentElement)}");

				elements.ParentElement = this;
				elements.SetReferences();
			}

			foreach (var diagram in Diagrams)
			{
				if (diagram.ParentElement != null && diagram.ParentElement != this)
					throw new InvalidOperationException($"Invalid {nameof(diagram)}.{nameof(diagram.ParentElement)}");

				diagram.ParentElement = this;
				diagram.SetReferences();
			}

			foreach (var taggedValueEx in TaggedValuesEx)
			{
				if (taggedValueEx.ElementEx != null && taggedValueEx.ElementEx != this)
					throw new InvalidOperationException($"Invalid {nameof(taggedValueEx)}.{nameof(taggedValueEx.ElementEx)}");

				taggedValueEx.ElementEx = this;
				taggedValueEx.SetReferences();
			}

			foreach (var attributeEx in AttributesEx)
			{
				//if (attributeEx.ElementEx != null && attributeEx.ElementEx != this)
				//	throw new InvalidOperationException($"Invalid {nameof(attributeEx)}.{nameof(attributeEx.ElementEx)}");

				attributeEx.ElementEx = this;
				attributeEx.SetReferences();
			}

			foreach (var constraintEx in ConstraintsEx)
			{
				if (constraintEx.ElementEx != null && constraintEx.ElementEx != this)
					throw new InvalidOperationException($"Invalid {nameof(constraintEx)}.{nameof(constraintEx.ElementEx)}");

				constraintEx.ElementEx = this;
				constraintEx.SetReferences();
			}
		}

		public override string ToString()
			=> $"{WrappedElement.Name} | {WrappedElement.Type}";
	}
}
