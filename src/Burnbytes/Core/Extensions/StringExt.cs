namespace Burnbytes
{
    internal static class StringExt
    {
        public static string Format(this string @string, params object[] args) => string.Format(@string, args);
    }
}
