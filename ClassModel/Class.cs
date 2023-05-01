using System.Collections.Generic;
using System.Linq;

namespace ClassModel
{
	public class Class
	{
		public Namespace Namespace { get; set; }
		public string Name { get; set; }

		private string _fullName;
		public string FullName => _fullName ?? (_fullName =
			(string.IsNullOrWhiteSpace(Namespace?.FullName)
				? Name
				: $"{Namespace.FullName}.{Name}"));

		public string Description { get; set; }
		public Visibility Visibility { get; set; }
		public Persistence? Persistence { get; set; }
		public string Language { get; set; }
		public bool IsDataType { get; set; }
		public List<Class> SuperClasses { get; set; }
		public List<Class> ChildClasses { get; set; }
		public bool IsAbstract { get; set; }
		public bool IsDeprecated { get; set; }
		public List<Property> Properties { get; set; }

		public Class(bool isDataType)
		{
			IsDataType = isDataType;
			Visibility = Visibility.Public;
			SuperClasses = new List<Class>();
			ChildClasses = new List<Class>();
			Properties = new List<Property>();
		}

		public Class AddSuperClass(Class superClass)
		{
			superClass.ChildClasses.Add(this);
			SuperClasses.Add(superClass);
			return this;
		}

		public Class AddProperty(Property property)
		{
			property.DeclaredClass = this;
			Properties.Add(property);
			return this;
		}

		public List<KeyValuePair<string, Class>> GetAllSuperClasses()
			=> GetAllSuperClassesInternal(null);

		public List<KeyValuePair<string, Class>> GetAllSuperClassesInternal(string levelPrefix)
		{
			var result = new List<KeyValuePair<string, Class>>();

			if (1 < SuperClasses.Count)
			{

			}

			var index = 0;
			foreach (var superClass in SuperClasses)
			{
				index++;
				var prefix = string.IsNullOrWhiteSpace(levelPrefix)
					? index.ToString()
					: $"{levelPrefix}_{index}";

				result.Add(new KeyValuePair<string, Class>(prefix, superClass));
				result.AddRange(superClass.GetAllSuperClassesInternal(prefix));
			}

			return result.Distinct().ToList();
		}

		public List<Class> GetAllClasses()
		{
			var result = new List<Class> { this };

			foreach (var superClass in SuperClasses)
				result.AddRange(superClass.GetAllClasses());

			return result.Distinct().ToList();
		}

		public List<Property> GetAllProperties()
			=> GetAllClasses().SelectMany(x => x.Properties).ToList();

		public bool IsDataTypeHierarchy()
		{
			if (IsDataType)
				return true;

			if (0 < SuperClasses?.Count)
			{
				foreach (var superClass in SuperClasses)
					if (superClass.IsDataTypeHierarchy())
						return true;
			}

			return false;
		}

		public override string ToString()
			=> FullName;
	}
}
