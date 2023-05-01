using System;
using System.Collections.Generic;

namespace DbDiagramGen.EAModel
{
	public class EAConnector : IEAObject
	{
		public global::EA.IDualConnector WrappedConnector { get; }
		public EARepository Repository { get; }
		public int ID => WrappedConnector.ConnectorID;
		public string GUID => WrappedConnector.ConnectorGUID;

		public List<EAConstraint> Constraints { get; set; }
		public List<EATaggedValue> TaggedValues { get; set; }
		public EAConnectorEnd ClientEnd { get; set; }
		public EAConnectorEnd SupplierEnd { get; set; }

		public EAPackage Package { get; set; }
		public EAElement ClientEndElement { get; set; }
		public EAElement SupplierEndElement { get; set; }

		public EAConnector(global::EA.IDualConnector connector, EARepository repository)
		{
			WrappedConnector = connector;
			Repository = repository;

			Constraints = new List<EAConstraint>();
			TaggedValues = new List<EATaggedValue>();
		}

		private bool _initialized;
		public void Build()
		{
			if (_initialized)
				return;

			_initialized = true;

			if (WrappedConnector.Constraints != null)
				foreach (global::EA.IDualConstraint constraint in WrappedConnector.Constraints)
					Constraints.Add(Repository.AddOrGetEAConstraint(constraint));

			if (WrappedConnector.TaggedValues != null)
				foreach (global::EA.IDualTaggedValue taggedValue in WrappedConnector.TaggedValues)
					TaggedValues.Add(Repository.AddOrGetEATaggedValue(taggedValue));

			if (WrappedConnector.ClientEnd != null)
				ClientEnd = Repository.AddOrGetEAConnectorEnd(WrappedConnector.ClientEnd);

			if (WrappedConnector.SupplierEnd != null)
				SupplierEnd = Repository.AddOrGetEAConnectorEnd(WrappedConnector.SupplierEnd);
		}

		private bool _referencesSet;
		public void SetReferences()
		{
			if (_referencesSet)
				return;

			_referencesSet = true;

			foreach (var constraint in Constraints)
			{
				if (constraint.Attribute != null && constraint.Connector!= this)
					throw new InvalidOperationException($"Invalid {nameof(constraint)}.{nameof(constraint.Connector)}");

				constraint.Connector = this;
				constraint.SetReferences();
			}

			foreach (var taggedValues in TaggedValues)
			{
				if (taggedValues.Connector != null && taggedValues.Connector != this)
					throw new InvalidOperationException($"Invalid {nameof(taggedValues)}.{nameof(taggedValues.Connector)}");

				taggedValues.Connector = this;
				taggedValues.SetReferences();
			}

			if (ClientEnd != null)
			{
				if (ClientEnd.ConnectorClientEnd != null && ClientEnd.ConnectorClientEnd != this)
					throw new InvalidOperationException($"Invalid {nameof(ClientEnd)}.{nameof(ClientEnd.ConnectorClientEnd)}");

				ClientEnd.ConnectorClientEnd = this;
				ClientEnd.SetReferences();

				ClientEndElement = Repository.ElementsById[WrappedConnector.ClientID];
				ClientEnd.Element = ClientEndElement;
			}

			if (SupplierEnd != null)
			{
				if (SupplierEnd.ConnectorSupplierEnd != null && SupplierEnd.ConnectorSupplierEnd != this)
					throw new InvalidOperationException($"Invalid {nameof(SupplierEnd)}.{nameof(SupplierEnd.ConnectorSupplierEnd)}");

				SupplierEnd.ConnectorSupplierEnd = this;
				SupplierEnd.SetReferences();

				SupplierEndElement = Repository.ElementsById[WrappedConnector.SupplierID];
				SupplierEnd.Element = SupplierEndElement;
			}
		}

		public override string ToString()
			=> $"{WrappedConnector.Name} | {WrappedConnector.Type} | {ClientEndElement} -- {SupplierEndElement}";
	}
}
