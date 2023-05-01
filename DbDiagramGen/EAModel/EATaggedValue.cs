namespace DbDiagramGen.EAModel
{
	public class EATaggedValue : IEAObject
	{
		public global::EA.IDualTaggedValue WrappedTaggedValue { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		public EAConnector Connector { get; set; }
		public EAConnectorEnd ConnectorEnd { get; set; }
		public EAElement Element { get; set; }
		public EAElement ElementEx { get; set; }

		public EATaggedValue(global::EA.IDualTaggedValue taggedValue, EARepository repository)
		{
			WrappedTaggedValue = taggedValue;
			Repository = repository;
		}

		public void Build()
		{
		}

		public void SetReferences()
		{
		}
	}
}
