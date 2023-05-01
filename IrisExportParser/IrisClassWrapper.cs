using System.Collections.Generic;

namespace IrisExportParser
{
	public class IrisClassWrapper
	{
		public Class IrisClass { get; }

		public string Namespace { get; }
		public string Name { get; }

		private string _fullName;
		public string FullName => _fullName ?? (_fullName = 
			(string.IsNullOrWhiteSpace(Namespace)
				? Name
				: $"{Namespace}.{Name}"));

		public string SuperClasses { get; set; }

		public Dictionary<string, ClassProperty> IrisProperties { get; }

		public ClassModel.Class Class { get; set; }

		public IrisClassWrapper(Class irisClass, string @namespace, string className)
		{
			IrisClass = irisClass;
			Namespace = @namespace;
			Name = className;
			IrisProperties = new Dictionary<string, ClassProperty>();
		}
	}
}
