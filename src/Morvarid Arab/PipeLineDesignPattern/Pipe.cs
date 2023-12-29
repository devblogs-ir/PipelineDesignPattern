using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDesignPattern
{
    public abstract class Pipe(Action<HttpContext> next)
    {
        public Action<HttpContext> _next = next;

        public abstract void Handle(HttpContext context);
    }

    public class ExceptionHandlingPipe(Action<HttpContext> next) : Pipe(next)
    {
        public override void Handle(HttpContext context)
        {
            try
            {
                Console.WriteLine("Starting ExceptionHandling...");

                if (_next is not null) _next(context);
            }
            catch (IPAccessDenied ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class AuthenticationPipe(Action<HttpContext> next) : Pipe(next)
    {
        public override void Handle(HttpContext context)
        {
            Console.WriteLine("Starting Authentication...");


            if (context.IP == "10.10.1.1")
            {
                throw new IPAccessDenied("Invalid IP");
            }

            if (_next is not null) _next(context);
        }
    }


    public class EndPointPipe(Action<HttpContext> next) : Pipe(next)
    {
        public override void Handle(HttpContext context)
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

            if (_next is not null) _next(context);
        }
    }


    public class PipelineBuilder
    {
        private List<Type> _pipes = new List<Type>();

        public PipelineBuilder AddPipe(Type pipe)
        {
            _pipes.Add(pipe);
            return this;
        }

        internal void Run(HttpContext requestFromIran)
        {
            
        }
    }
}
