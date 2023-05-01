using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EAAttribute : IEAObject
	{
		public global::EA.IDualAttribute WrappedAttribute { get; }
		public EARepository Repository { get; }
		public int ID => WrappedAttribute.AttributeID;
		public string GUID => WrappedAttribute.AttributeGUID;

		public List<EAConstraint> Constraints { get; set; }
		public List<EAAttributeTag> TaggedValues { get; set; }
		public List<EAAttributeTag> TaggedValuesEx { get; set; }

		public EAElement Element { get; set; }
		public EAElement ElementEx { get; set; }

		public EAAttribute(global::EA.IDualAttribute attribute, EARepository repository)
		{
			WrappedAttribute = attribute;
			Repository = repository;

			Constraints = new List<EAConstraint>();
			TaggedValues = new List<EAAttributeTag>();
			TaggedValuesEx = new List<EAAttributeTag>();
		}

		private bool _initialized;
		public void Build()
		{
			if (_initialized)
				return;

			_initialized = true;

			if (WrappedAttribute.Constraints != null)
				foreach (global::EA.IDualConstraint constraint in WrappedAttribute.Constraints)
					Constraints.Add(Repository.AddOrGetEAConstraint(constraint));

			if (WrappedAttribute.TaggedValues != null)
				foreach (global::EA.IDualAttributeTag attributeTag in WrappedAttribute.TaggedValues)
					TaggedValues.Add(Repository.AddOrGetEAAttributeTag(attributeTag));

			if (WrappedAttribute.TaggedValuesEx != null)
				foreach (global::EA.IDualAttributeTag attributeTagEx in WrappedAttribute.TaggedValuesEx)
					TaggedValuesEx.Add(Repository.AddOrGetEAAttributeTag(attributeTagEx));
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			foreach (var constraint in Constraints)
			{
				if (constraint.Attribute != null && constraint.Attribute != this)
					throw new InvalidOperationException($"Invalid {nameof(constraint)}.{nameof(constraint.Attribute)}");
				
				constraint.Attribute = this;
				constraint.SetReferences();
			}

			foreach (var taggedValues in TaggedValues)
			{
				if (taggedValues.Attribute != null && taggedValues.Attribute != this)
					throw new InvalidOperationException($"Invalid {nameof(taggedValues)}.{nameof(taggedValues.Attribute)}");

				taggedValues.Attribute = this;
				taggedValues.SetReferences();
			}

			foreach (var taggedValuesEx in TaggedValuesEx)
			{
				if (taggedValuesEx.Attribute != null && taggedValuesEx.Attribute != this)
					throw new InvalidOperationException($"Invalid {nameof(taggedValuesEx)}.{nameof(taggedValuesEx.Attribute)}");

				taggedValuesEx.Attribute = this;
				taggedValuesEx.SetReferences();
			}
		}

		public override string ToString()
			=> $"{WrappedAttribute.Name} | {WrappedAttribute.Type} | {Element}";
	}
}
