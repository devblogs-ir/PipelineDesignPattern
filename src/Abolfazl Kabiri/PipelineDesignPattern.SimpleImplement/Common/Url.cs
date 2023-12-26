namespace PipelineDesignPattern.SimpleImplement;
public static class Url
{
    public static string GetController(string url)
    {
        if (url is null) return null;
        var sections = url.Split('/');
        return sections[sections.Length - 2];
    }
    public static string GetAction(string url)
    {
        if (url is null) return null;
        var sections = url.Split('/');
        return sections[sections.Length - 1];
    }
}
