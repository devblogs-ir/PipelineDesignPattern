namespace PipelineDesignPattern.SimpleImplement.Common;
public static class ExtentionMethods
{
    public static bool IsInstancable(this Type type)
    {
        if (type is null) return false;
        if (!type.IsClass) return false;
        if (type.IsAbstract) return false;
        return true;
    }
}
