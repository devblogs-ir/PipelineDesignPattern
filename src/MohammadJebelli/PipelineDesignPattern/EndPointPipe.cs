using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class EndPointPipe : Pipe
    {
        public EndPointPipe(Action<HttpContext> next) : base(next)
        {
        }

        public override void Handle(HttpContext httpContext)
        {
            var splitted = httpContext.Url.Split('/');
            var partsCount = splitted.Length;
            var ControllerName = splitted[splitted.Length - 2];
            var ActionName= splitted[splitted.Length - 1];

            var templateControllerName = $"PipelineDesignPattern.{ControllerName}Controller";

            var type = Type.GetType(templateControllerName);

            var instance = Activator.CreateInstance(type, new[] {httpContext} );

            MethodInfo method = type.GetMethod(ActionName);

            method.Invoke(instance, null);
           
            
        }
    }
}
