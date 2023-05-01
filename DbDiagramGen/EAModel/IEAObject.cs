namespace DbDiagramGen.EAModel
{
	public interface IEAObject
	{
		EARepository Repository { get; }

		int ID { get; }

		string GUID { get; }

		void Build();

		void SetReferences();
	}
}
