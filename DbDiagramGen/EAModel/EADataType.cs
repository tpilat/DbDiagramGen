namespace DbDiagramGen.EAModel
{
	public class EADataType : IEAObject
	{
		public global::EA.IDualDatatype WrappedDataType { get; }
		public EARepository Repository { get; }
		public int ID => WrappedDataType.DatatypeID;
		public string GUID => "";

		public EADataType(global::EA.IDualDatatype dataType, EARepository repository)
		{
			WrappedDataType = dataType;
			Repository = repository;
		}

		public void Build()
		{
		}

		public void SetReferences()
		{
		}

		public override string ToString()
			=> $"{WrappedDataType.Product} | {WrappedDataType.Name} | {WrappedDataType.Type} | {WrappedDataType.GenericType}";
	}
}
