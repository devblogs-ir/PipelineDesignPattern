using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern.Pipes
{
    public class EndPointPipe : Pipe
    {
        public EndPointPipe() : base() { }
        public EndPointPipe(HttpContent httpContent)
        {

        }
        public override void Handle(HttpContext httpContext)
        {
            var parts = httpContext.Url.Split('/');
            var controllerClass = parts[1];
            var actionMethod = parts[2];
            var userId = parts[3];
            var templateControllerName = $"PipelineDesignPattern.Controllers.{controllerClass}Controller";
            var typeController = Type.GetType(templateControllerName);
            MethodInfo method = typeController.GetMethod(actionMethod);
            var parametersInfo = method.GetParameters();

            var userIdAsInt = Convert.ChangeType(userId, parametersInfo[0].ParameterType);


            var instance = Activator.CreateInstance(typeController, new[] { httpContext });
            //var productsController = instance as ProductsController;

            method.Invoke(instance, new[] { userIdAsInt });

            if (_next != null)
                _next(httpContext);
        }
    }
}
