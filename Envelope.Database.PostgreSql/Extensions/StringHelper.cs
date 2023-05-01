namespace Envelope.Text
{
	public static class StringHelper
	{
		public static string ConcatIfNotNullOrEmpty(this string source, string delimiter, string text)
		{
			if (string.IsNullOrEmpty(source))
				return text ?? source;

			if (string.IsNullOrEmpty(text))
				return source ?? text;

			return string.Concat(source, delimiter, text);
		}
	}
}
