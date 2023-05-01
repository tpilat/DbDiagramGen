using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EADiagram : IEAObject
	{
		public global::EA.IDualDiagram WrappedDiagram { get; }
		public EARepository Repository { get; }
		public int ID => WrappedDiagram.DiagramID;
		public string GUID => WrappedDiagram.DiagramGUID;

		public List<EADiagramObject> DiagramObjects { get; set; }
		public List<EADiagramLink> DiagramLinks { get; set; }

		public EAPackage Package { get; set; }
		public EAElement ParentElement { get; set; }

		public EADiagram(global::EA.IDualDiagram diagram, EARepository repository)
		{
			WrappedDiagram = diagram;
			Repository = repository;
			DiagramObjects = new List<EADiagramObject>();
			DiagramLinks = new List<EADiagramLink>();
		}

		private bool _initialized;
		public void Build()
		{
			if (_initialized)
				return;

			_initialized = true;

			if (WrappedDiagram.DiagramObjects != null)
				foreach (global::EA.IDualDiagramObject diagramObject in WrappedDiagram.DiagramObjects)
					DiagramObjects.Add(Repository.AddOrGetEADiagramObject(diagramObject));

			if (WrappedDiagram.DiagramLinks != null)
				foreach (global::EA.IDualDiagramLink diagramLink in WrappedDiagram.DiagramLinks)
					DiagramLinks.Add(Repository.AddOrGetEADiagramLink(diagramLink));
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			foreach (var diagramObject in DiagramObjects)
			{
				if (diagramObject.Diagram != null && diagramObject.Diagram != this)
					throw new InvalidOperationException($"Invalid {nameof(diagramObject)}.{nameof(diagramObject.Diagram)}");

				diagramObject.Diagram = this;
				diagramObject.SetReferences();
			}

			foreach (var diagramLink in DiagramLinks)
			{
				if (diagramLink.Diagram != null && diagramLink.Diagram != this)
					throw new InvalidOperationException($"Invalid {nameof(diagramLink)}.{nameof(diagramLink.Diagram)}");

				diagramLink.Diagram = this;
				diagramLink.SetReferences();
			}
		}

		public override string ToString()
			=> $"{WrappedDiagram.Name} | {WrappedDiagram.Type}";
	}
}
