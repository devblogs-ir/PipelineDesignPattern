using PipelineDesignPattern.Exceptions;
using System.Reflection;
using System.Text;

namespace PipelineDesignPattern.Common;

public static class RequestExtensions
{
    public static object InvokeWithParameters(this MethodInfo method, object instance, string inputParams)
    {
        var parameters = method.GetParameters();

        if (string.IsNullOrEmpty(inputParams))
            throw new InvalidBindingException(@$"invalid input for method {method.Name},
                                                 this method contains this paramters 
                                                 {parameters.ExtractParameters()}");

        var queryValues = inputParams.ExtractQueryString();

        object[] finalParameters = new object[queryValues.Count];

        for (var i = 0; i < parameters.Length; i++)
        {
            finalParameters[i] = Convert.ChangeType(queryValues[i], parameters[i].ParameterType);
        }
        var result = method.Invoke(instance, finalParameters);

        return result!;
    }

    public static (string Controller, string Method, string Query) SplitRoute(this string route)
    {
        var fullRoute = route.Split('?');
        string query = string.Empty;
        if (fullRoute.Length == 2)
        {
            query = fullRoute[1];
        }
        var internalRoute = fullRoute[0].Split('/');

        var controller = internalRoute[0];
        var method = internalRoute[1];

        return (controller, method, query);
    }
    public static List<object> ExtractQueryString(this string input)
    {
        var parts = input.Split("&");
        string[] section = new string[2];

        List<object> result = [];

        foreach (var part in parts)
        {
            section = part.Split('=');
            result.Add(section[1]);
        }
        return result;
    }
    public static string ExtractParameters(this ParameterInfo[]? parameters)
    {
        StringBuilder sb = new();

        foreach (var parameter in parameters!)
            sb.Append($"{parameter.Name} of type {parameter.ParameterType}");

        return sb.ToString();
    }
}
