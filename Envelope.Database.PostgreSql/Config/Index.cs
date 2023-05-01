using Envelope.Text;
using Envelope.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Envelope.Database.Config
{
	public class Index : IValidable
	{
		public string Name { get; set; }
		public List<string> Columns { get; set; }

		public List<IValidationMessage> Validate(string propertyPrefix = null, List<IValidationMessage> parentErrorBuffer = null, Dictionary<string, object> validationContext = null)
		{
			if (parentErrorBuffer == null)
				parentErrorBuffer = new List<IValidationMessage>();

			if (string.IsNullOrWhiteSpace(Name))
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(Name))} == null"));

			if (Columns == null)
			{
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(Columns))} == null"));
			}
			else if (Columns.Count == 0)
			{
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(Columns))}.{nameof(Columns.Count)} == 0"));
			}
			else
			{
				for (int i = 0; i < Columns.Count; i++)
					if (string.IsNullOrWhiteSpace(Columns[i]))
						parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", $"{nameof(Columns)}[{i}]")} == null"));
			}

			return parentErrorBuffer;
		}

		public Index Clone()
			=> new Index()
			{
				Name = Name,
				Columns = Columns?.ToList()
			};

		public override string ToString()
		{
			return $"{Name}: {string.Join(", ", Columns ?? new List<string>())}";
		}
	}
}