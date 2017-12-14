namespace Cake.Flyway
{
    internal static class BooleanExtensions
    {
        internal static string ToLowerString(this bool? x)
        {
            return x?.ToString().ToLowerInvariant();
        }
    }
}
