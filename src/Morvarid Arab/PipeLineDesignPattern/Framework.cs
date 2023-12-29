using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDesignPattern
{
    public class Framework
    {
        public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                action(context);
            }
            catch (IPAccessDenied ex)
            {
                ex.Message.Dump(label: "IP access denied");
            }
        }

        public void Authentication(HttpContext context, Action<HttpContext> action)
        {
            if (context.IP == "10.10.1.1")
            {
                throw new IPAccessDenied("Invalid IP");
            }
            action(context);
        }

        public void EndPointHandling(HttpContext context, Action<HttpContext> action)
        {
            var parts = context.URL.Split('/');

            var controllerClass = parts[1];
            var actionMethod = parts[2];
            var userId = parts[3];

            var templateControllerName = $"PipeLineDesignPattern.Controllers.{controllerClass}Controller";
            var typeController = Type.GetType(templateControllerName);
            MethodInfo method = typeController.GetMethod(actionMethod);

            var parameterInfos = method.GetParameters();

            var userIdAsInt = Convert.ChangeType(userId, parameterInfos[0].ParameterType);

            var instance = Activator.CreateInstance(typeController, new[] { context });
            method.Invoke(instance, new[] { userIdAsInt });
        }
    }
}
