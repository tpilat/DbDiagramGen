namespace DbDiagramGen.EAModel
{
	public class EAConstraint : IEAObject
	{
		public global::EA.IDualConstraint WrappedConstraint { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		public EAAttribute Attribute { get; set; }
		public EAConnector Connector { get; set; }
		public EAElement Element { get; set; }
		public EAElement ElementEx { get; set; }

		public EAConstraint(global::EA.IDualConstraint constraint, EARepository repository)
		{
			WrappedConstraint = constraint;
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
