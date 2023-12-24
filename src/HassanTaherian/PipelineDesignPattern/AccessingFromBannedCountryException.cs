namespace PipelineDesignPattern;

public class AccessingFromBannedCountryException(string countryName) : Exception(Messages.AccessingFromBannedCountryException(countryName))
{
}