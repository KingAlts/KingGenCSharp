namespace KingGen;

internal static class EndpointExtensions
{
    internal static string Build(this Endpoint endpoint) => endpoint.ToString().ToLower();
}