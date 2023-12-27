using Dumpify;
using System.Reflection;

namespace PipelineDesignPattern
{
    public class Framework
    {
        public delegate void Action(HttpContext context);
        public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                action(context);
            }
            catch (CustomException ex)
            {
                ex.Message.Dump();
            }
        }
        public void Cors(HttpContext context, Action<HttpContext> action)
        {
            if (context is null) throw new CustomException("context is null ");
            if (context.IP is null) throw new CustomException("IP is null ");
            action(context);
            "end Cors".Dump();
        }
        public void Routing(HttpContext context, Action<HttpContext> action)
        {
            "Routing".Dump();
            if (context is null) throw new CustomException("context is null ");
            if (context.IP is null) throw new CustomException("IP is null ");
            action(context);

        }
        public void Authentication(HttpContext context, Action<HttpContext> action)
        {
            "begin Authentication".Dump();
            if (context is null) throw new CustomException("context is null ");
            if (context.IP is null) throw new CustomException("IP is null ");
            if (context.IP == "192.15.0.0") throw new CustomException("you are from Iran");


            action(context);
            "end Authentication".Dump();


        }

        public void EndpointHandling(HttpContext context, Action<HttpContext> action)
        {
            var urlParts = context.Url.Split('/');
            var methodName = "";
            var controllerName = "";
            var UserId = "";
            try 
            {
                UserId = urlParts[5];
                methodName = urlParts[4];
                controllerName = urlParts[3];
            }
            catch
            {
                throw new CustomException(" Url Not Valid ");
            }
            
            var templateControllerName = $"PipelineDesignPattern.{controllerName}Controller";
            var typeController = Type.GetType(templateControllerName)??
                throw new CustomException(" type Not Found ");

            var instanceController = Activator
                .CreateInstance(typeController,new[] { context }) ??
                throw new CustomException(" Controller Not Found ");

            MethodInfo method=typeController.GetMethod(methodName) ?? 
                throw new CustomException(" method Not Found ");
            var parameters=method.GetParameters();
            
            var userIdAsInt = Convert.ChangeType(
                UserId, 
                parameters[0].ParameterType);

            method.Invoke(instanceController,new[] { userIdAsInt });
            
        }


    }
}
