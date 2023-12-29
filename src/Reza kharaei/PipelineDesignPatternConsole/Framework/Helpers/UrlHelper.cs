using PipelineDesignPatternConsole.Models;

namespace PipelineDesignPatternConsole.Framework.Helpers;

public static class UrlHelper
{
    private static int? TryParseNullable(string val)
    {
        int outValue;
        return int.TryParse(val, out outValue) ? (int?)outValue : null;
    }

    public  static RoutingContext ParseUrl(string url)
    {
        var result = new RoutingContext();
        
        var SplitedUrl = url.Split('/');
        result.parameterId = TryParseNullable(SplitedUrl[SplitedUrl.Length - 1]); 
         
        if (result.parameterId.HasValue)
        {
            result.controllerName = SplitedUrl[SplitedUrl.Length - 3];
            result.actionName = SplitedUrl[SplitedUrl.Length - 2];
        }
        else
        {
            result.controllerName = SplitedUrl[SplitedUrl.Length - 2];
            result.actionName = SplitedUrl[SplitedUrl.Length - 1];
        }

        return result;
    }
}