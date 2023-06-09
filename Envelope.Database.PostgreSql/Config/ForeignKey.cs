using Envelope.Text;
using Envelope.Validation;
using System.Collections.Generic;

namespace Envelope.Database.Config
{
	public class ForeignKey : IValidable
	{
		public string Name { get; set; }
		public string Column { get; set; }
		public string ForeignSchemaAlias { get; set; }
		public string ForeignTableName { get; set; }
		public string ForeignColumnName { get; set; }
		public ReferentialAction? OnUpdateAction { get; set; }
		public ReferentialAction? OnDeleteAction { get; set; }

		public List<IValidationMessage> Validate(string propertyPrefix = null, List<IValidationMessage> parentErrorBuffer = null, Dictionary<string, object> validationContext = null)
		{
			if (parentErrorBuffer == null)
				parentErrorBuffer = new List<IValidationMessage>();

			if (string.IsNullOrWhiteSpace(Name))
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(Name))} == null"));

			if (string.IsNullOrWhiteSpace(Column))
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(Column))} == null"));

			if (string.IsNullOrWhiteSpace(ForeignSchemaAlias))
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(ForeignSchemaAlias))} == null"));

			if (string.IsNullOrWhiteSpace(ForeignTableName))
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(ForeignTableName))} == null"));

			if (string.IsNullOrWhiteSpace(ForeignColumnName))
				parentErrorBuffer.Add(ValidationMessageFactory.Error($"{propertyPrefix.ConcatIfNotNullOrEmpty(".", nameof(ForeignColumnName))} == null"));

			return parentErrorBuffer;
		}

		public ForeignKey Clone()
			=> new ForeignKey()
			{
				Name = Name,
				Column = Column,
				ForeignSchemaAlias = ForeignSchemaAlias,
				ForeignTableName = ForeignTableName,
				ForeignColumnName = ForeignColumnName,
				OnUpdateAction = OnUpdateAction,
				OnDeleteAction = OnDeleteAction
			};

		public override string ToString()
		{
			return Name;
		}
	}
}