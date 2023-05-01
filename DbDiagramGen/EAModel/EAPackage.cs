using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EAPackage : IEAObject
	{
		public global::EA.IDualPackage WrappedPackage { get; }
		public EARepository Repository { get; }
		public int ID => WrappedPackage.PackageID;
		public string GUID => WrappedPackage.PackageGUID;

		public bool IsModel => WrappedPackage.IsModel;

		public EAElement Element { get; set; }
		public List<EAPackage> Packages { get; set; }
		public List<EAElement> Elements { get; set; }
		public List<EADiagram> Diagrams { get; set; }
		public List<EAConnector> Connectors { get; set; }

		public EAPackage ParentPackage { get; set; }

		public EAPackage(global::EA.IDualPackage package, EARepository repository)
		{
			WrappedPackage = package;
			Repository = repository;

			Packages = new List<EAPackage>();
			Elements = new List<EAElement>();
			Diagrams = new List<EADiagram>();
			Connectors = new List<EAConnector>();
		}

		private bool _initialized;
		public void Build()
		{
			if (_initialized)
				return;

			_initialized = true;

			if (WrappedPackage.Packages != null)
				foreach (global::EA.IDualPackage nestedPackage in WrappedPackage.Packages)
					Packages.Add(Repository.AddOrGetEAPackage(nestedPackage));

			if (WrappedPackage.Elements != null)
				foreach (global::EA.IDualElement element in WrappedPackage.Elements)
					Elements.Add(Repository.AddOrGetEAElement(element));

			if (WrappedPackage.Diagrams != null)
				foreach (global::EA.IDualDiagram diagram in WrappedPackage.Diagrams)
					Diagrams.Add(Repository.AddOrGetEADiagram(diagram));

			if (WrappedPackage.Connectors != null)
				foreach (global::EA.IDualConnector connector in WrappedPackage.Connectors)
					Connectors.Add(Repository.AddOrGetEAConnector(connector));

			if (WrappedPackage.Element != null)
				Element = Repository.AddOrGetEAElement(WrappedPackage.Element);
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			foreach (var package in Packages)
			{
				if (package.ParentPackage != null && package.ParentPackage != this)
					throw new InvalidOperationException($"Invalid {nameof(package)}.{nameof(package.ParentPackage)}");

				package.ParentPackage = this;
				package.SetReferences();
			}

			foreach (var element in Elements)
			{
				if (element.Package != null && element.Package != this)
					throw new InvalidOperationException($"Invalid {nameof(element)}.{nameof(element.Package)}");

				element.Package = this;
				element.SetReferences();
			}

			foreach (var diagram in Diagrams)
			{
				if (diagram.Package != null && diagram.Package != this)
					throw new InvalidOperationException($"Invalid {nameof(diagram)}.{nameof(diagram.Package)}");

				diagram.Package = this;
				diagram.SetReferences();
			}

			foreach (var connector in Connectors)
			{
				if (connector.Package != null && connector.Package != this)
					throw new InvalidOperationException($"Invalid {nameof(connector)}.{nameof(connector.Package)}");

				connector.Package = this;
				connector.SetReferences();
			}
		}

		public override string ToString()
			=> $"{WrappedPackage.Name}";
	}
}
