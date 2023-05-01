namespace DbDiagramGen.EAModel
{
	public class EADiagramLink : IEAObject
	{
		public global::EA.IDualDiagramLink WrappedDiagramLink { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		public EAConnector Connector { get; set; }

		public EADiagram Diagram { get; set; }

		public EADiagramLink(global::EA.IDualDiagramLink diagramLink, EARepository repository)
		{
			WrappedDiagramLink = diagramLink;
			Repository = repository;
		}

		public void Build()
		{
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			Connector = Repository.ConnectorsById[WrappedDiagramLink.ConnectorID];
		}

		public override string ToString()
			=> Connector?.ToString() ?? "";
	}
}
