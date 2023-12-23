namespace PipelineDesignPattern;

public static class Messages
{
    public static string AccessingFromBannedCountryException(string countryName)
    {
        return $"We're sorry! We can't service customers from {countryName}:(";
    }
}

