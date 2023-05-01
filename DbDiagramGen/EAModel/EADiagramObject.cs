namespace DbDiagramGen.EAModel
{
	public class EADiagramObject : IEAObject
	{
		public global::EA.IDualDiagramObject WrappedDiagramObject { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		public EAElement Element { get; set; }

		public EADiagram Diagram { get; set; }

		public EADiagramObject(global::EA.IDualDiagramObject diagramObject, EARepository repository)
		{
			WrappedDiagramObject = diagramObject;
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

			Element = Repository.ElementsById[WrappedDiagramObject.ElementID];
		}

		public override string ToString()
			=> Element?.ToString() ?? "";
	}
}
