//namespace PipelineCLITool;
//public class Framework
//{
//    public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> function)
//    {
//        try
//        {
//            if (httpContext.IP is "Iran")
//                throw new BannedIPException(httpContext.IP);
//            function(httpContext);
//        }
//        catch (BannedIPException ex)
//        {
//            ex.Message.Dump();
//        }
//    }

//    public void AuthenticationHandling(HttpContext httpContext, Action<HttpContext> function)
//    {
//        $"Authentication Started for {httpContext.IP}".Dump();
//        function(httpContext);
//        $"Authentication Ended for {httpContext.IP}".Dump();
//    }
//    public void EndpointHandling(HttpContext httpContext, Action<HttpContext> function)
//    {
//        $"Routing...".Dump();
//        try
//        {
//            var parts = httpContext.Url.Split('/');

//            var controllerName = parts[1];
//            var actionName = parts[2];
//            string userId;

//            if (string.IsNullOrEmpty(controllerName))
//                throw new NoControllerProvidedException();

//            if (string.IsNullOrEmpty(actionName))
//                throw new NoActionProvidedException();

//            var controllerNameTemplate = $"PipelineCLITool.{controllerName}Controller";
//            var controllerType = Type.GetType(controllerNameTemplate);
//            var controllerInstance = Activator.CreateInstance(controllerType, new[] { httpContext });

//            var methodInfo = controllerType.GetMethod(actionName);

//            if (methodInfo is null)
//                throw new RouteNotFoundException();

//            var parameterList = methodInfo.GetParameters();

//            if (parameterList.Length > 0 && parts.Length > 3)
//            {
//                userId = parts[3];

//                if (string.IsNullOrEmpty(actionName))
//                    throw new NoParameterProvidedException();

//                object[] parameters = new object[parameterList.Length];
//                for (int i = 0; i < parameterList.Length; i++)
//                {
//                    var convertedParameter = Convert.ChangeType(userId, parameterList[i].ParameterType);
//                    //var convertToType = $"To{parameterList[i].ParameterType.Name}";
//                    //var convertType = typeof(Convert);
//                    //var convertMethod = convertType.GetMethod(convertToType, new[] { typeof(object) });
//                    //if (convertMethod is null)
//                    //    throw new Exception("Something went wrong!");
//                    //var convertedValue = convertMethod.Invoke(null, new object[] { userId });
//                    parameters[i] = convertedParameter;
//                }
//                methodInfo.Invoke(controllerInstance, parameters);
//            }
//            else
//            {
//                methodInfo.Invoke(controllerInstance, null);
//            }
//        }
//        catch (NoControllerProvidedException ex)
//        {
//            ex.Message.Dump();
//        }
//        catch (NoActionProvidedException ex)
//        {
//            ex.Message.Dump();
//        }
//        catch (RouteNotFoundException ex)
//        {
//            ex.Message.Dump();
//        }
//        catch (Exception ex)
//        {
//            ex.Message.Dump();
//        }
//    }
//}
