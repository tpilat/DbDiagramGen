namespace ClassModel
{
	public class Property
	{
		public Class DeclaredClass { get; set; }
		public Class Type { get; set; }
		public bool IsDataType { get; set; }
		public string TypeFullName { get; set; }
		public bool IsMultiDimensional { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsCalculated { get; set; }
		public bool IsIdentity { get; set; }
		public bool IsDeprecated { get; set; }
		public Visibility Visibility { get; set; }
		public bool IsReadOnly { get; set; }
		public bool IsRelationship { get; set; }
		public bool IsRequired { get; set; }
		public bool IsTransient { get; set; }
		public string InitialExpression { get; set; }
		public Cardinality? Cardinality { get; set; }
		public CollectionEnum? Collection { get; set; }
		public string InversePropertyName { get; set; }

		public bool LinkedToReferencedType { get; set; }

		public Property()
		{
			Visibility = Visibility.Public;
		}

		public override string ToString()
			=> $"{((Type == null) ? TypeFullName : Type.FullName)} {Name}";
	}
}
