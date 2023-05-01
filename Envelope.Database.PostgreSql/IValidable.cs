using System.Collections.Generic;

namespace Envelope.Validation
{
	public interface IValidable
	{
		List<IValidationMessage> Validate(string propertyPrefix = null, List<IValidationMessage> parentErrorBuffer = null, Dictionary<string, object> validationContext = null);
	}
}
