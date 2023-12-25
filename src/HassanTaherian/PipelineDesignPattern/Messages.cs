namespace PipelineDesignPattern;

public static class Messages
{
    public static string AccessingFromBannedCountryException(string countryName)
    {
        return $"We're sorry! We can't service customers from {countryName}:(";
    }

    public static string InvalidUrlFormatException()
    {
        return "URL format mush be {controller}/{action}/{parameter}";
    }

    public static string EndPointNotFoundException(string url)
    {
        return $"URL {url} not found!";
    }
}

