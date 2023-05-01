using System.Collections.Generic;

namespace ClassModel
{
	public class Namespace
	{
		public Namespace Parent { get; set; }
		public List<Namespace> NestedNamespaces { get; set; }
		public string Name { get; set; }

		private string _fullName;
		public string FullName => _fullName ?? (_fullName =
			(Parent == null
				? Name
				: $"{Parent.FullName}.{Name}"));

		public List<Class> Classes { get; set; }
		public string Description { get; set; }

		public Namespace()
		{
			Classes = new List<Class>();
			NestedNamespaces = new List<Namespace>();
		}

		public Namespace AddNestedNamespace(Namespace @namespace)
		{
			@namespace.Parent = this;
			NestedNamespaces.Add(@namespace);
			return this;
		}

		public Namespace AddClass(Class @class)
		{
			@class.Namespace = this;
			Classes.Add(@class);
			return this;
		}

		private bool? _hasAnyClass;
		public bool HasAnyClassInHierarchy()
		{
			if (_hasAnyClass.HasValue)
				return _hasAnyClass.Value;

			if (0 < Classes.Count)
			{
				_hasAnyClass = true;
				return _hasAnyClass.Value;
			}

			foreach (var nestedNamespace in NestedNamespaces)
			{
				if (nestedNamespace.HasAnyClassInHierarchy())
				{
					_hasAnyClass = true;
					return _hasAnyClass.Value;
				}
			}

			_hasAnyClass = false;
			return _hasAnyClass.Value;
		}

		public override string ToString()
			=> $"{FullName} | [{Classes?.Count ?? 0}]";
	}
}
