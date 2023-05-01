using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramGen.EAModel
{
	public class EAModel : IEAObject
	{
		//public global::EA.IDualModel WrappedModel { get; }
		public EARepository Repository { get; }
		public int ID => -1;
		public string GUID => "";

		//public EAModel(global::EA.IDualModel model)
		//{
		//	WrappedModel = model;
		//}

		private bool _initialized;
		public void Initialize()
		{
			if (_initialized)
				return;

			_initialized = true;
		}

		private bool _referencesSet;
		public void SetReferences(EARepository repository)
		{
			if (_referencesSet)
				return;

			_referencesSet = true;
		}
	}
}
