using System;

namespace Envelope.Enums
{
	public static class EnumHelper
	{
		public static TEnum ConvertStringToEnum<TEnum>(string enumStringValue, bool ignoreCase) where TEnum : struct, IComparable, IFormattable, IConvertible
		{
			if (Enum.TryParse(enumStringValue, ignoreCase, out TEnum result))
				return result;
			else
				throw new System.ArgumentException($"Requested string enum value {enumStringValue} was not found in enum type {typeof(TEnum).FullName}");
		}
	}
}
