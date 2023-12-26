using PipelineDesignPattern.SimpleImplement.CustomExceptions;

namespace PipelineDesignPattern.SimpleImplement;
public static class Url
{
    public static (string Controller, string Action) GetUrlPath(string url)
    {
        if (url is null) throw new InvalidRequestException(url);
        var sections = url.Split('/');
        return (sections[sections.Length - 2], sections[sections.Length - 1]);
    }
}
