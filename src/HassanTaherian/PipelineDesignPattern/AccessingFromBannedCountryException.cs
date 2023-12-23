namespace PipelineDesignPattern;

public class AccessingFromBannedCountryException : Exception
{
    public AccessingFromBannedCountryException(string countryName) : base(Messages.AccessingFromBannedCountryException(countryName))
    {

    }
}