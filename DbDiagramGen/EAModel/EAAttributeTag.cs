namespace DbDiagramGen.EAModel
{
	public class EAAttributeTag : IEAObject
	{
		public global::EA.IDualAttributeTag WrappedTaggedValue { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		public EAAttribute Attribute { get; set; }

		public EAAttributeTag(global::EA.IDualAttributeTag taggedValue, EARepository repository)
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
