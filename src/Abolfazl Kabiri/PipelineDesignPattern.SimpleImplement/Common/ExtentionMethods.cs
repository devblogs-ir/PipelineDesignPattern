namespace PipelineDesignPattern.SimpleImplement.Common;
public static class ExtentionMethods
{
    public static bool IsInstancable(this Type type)
    {
        if (
            type is null |
            !type.IsClass |
            type.IsAbstract
           ) return false;
        return true;
    }
}
