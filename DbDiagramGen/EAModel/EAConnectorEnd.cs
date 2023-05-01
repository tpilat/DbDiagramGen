using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EAConnectorEnd : IEAObject
	{
		public global::EA.IDualConnectorEnd WrappedConnectorEnd { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		public List<EATaggedValue> TaggedValues { get; set; }

		public EAConnector ConnectorClientEnd { get; set; }
		public EAConnector ConnectorSupplierEnd { get; set; }
		public EAElement Element { get; set; }

		public EAConnectorEnd(global::EA.IDualConnectorEnd connectorEnd, EARepository repository)
		{
			WrappedConnectorEnd = connectorEnd;
			Repository = repository;

			TaggedValues = new List<EATaggedValue>();
		}

		private bool _initialized;
		public void Build()
		{
			if (_initialized)
				return;

			_initialized = true;

			if (WrappedConnectorEnd.TaggedValues != null)
				foreach (global::EA.IDualTaggedValue taggedValue in WrappedConnectorEnd.TaggedValues)
					TaggedValues.Add(Repository.AddOrGetEATaggedValue(taggedValue));
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			foreach (var taggedValues in TaggedValues)
			{
				if (taggedValues.ConnectorEnd != null && taggedValues.ConnectorEnd != this)
					throw new InvalidOperationException($"Invalid {nameof(taggedValues)}.{nameof(taggedValues.ConnectorEnd)}");

				taggedValues.ConnectorEnd = this;
				taggedValues.SetReferences();
			}
		}

		public override string ToString()
			=> $"{WrappedConnectorEnd.End} | {WrappedConnectorEnd.Cardinality} - {Element}";
	}
}
