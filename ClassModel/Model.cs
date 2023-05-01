using System.Collections.Generic;
using System.Linq;

namespace ClassModel
{
	public class Model
	{
		public List<Namespace> Namespaces { get; set; }
		public string Description { get; set; }

		public Model()
		{
			Namespaces = new List<Namespace>();
		}

		public Model AddNamespace(Namespace @namespace)
		{
			Namespaces.Add(@namespace);
			return this;
		}

		public List<Namespace> GetAllNamesapces()
		{
			var result = new List<Namespace>();

			if (Namespaces == null)
				return result;

			foreach (var @namespace in Namespaces)
				result.AddRange(GetAllNamesapces(@namespace));

			result = result.OrderBy(x => x.FullName).ToList();
			return result;
		}

		private List<Namespace> GetAllNamesapces(Namespace @namespace)
		{
			var result = new List<Namespace> { @namespace };

			if (@namespace?.NestedNamespaces == null)
				return result;

			foreach (var nestedNamespace in @namespace.NestedNamespaces)
				result.AddRange(GetAllNamesapces(nestedNamespace));

			return result;
		}

		public List<Class> GetAllClasses()
		{
			var result = new List<Class>();

			var namespaces = GetAllNamesapces();

			foreach (var @namespace in namespaces)
				if (0 < @namespace.Classes?.Count)
					result.AddRange(@namespace.Classes);

			result = result.OrderBy(x => x.FullName).ToList();
			return result;
		}
	}
}
