using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class PipeBuilder
    {
        private List<Type> pipes = new List<Type>();

        public PipeBuilder AddPipe(Type type)
        {
            pipes.Add(type);
            return this;
        }
        //private List<Pipe> builtPipes = new List<Pipe>();

        public PipeBuilder Build(HttpContext httpContext)
        {
            Action<HttpContext> finalAction = null;

            // Iterate through the pipes in reverse order to build the chain
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                var pipeType = pipes[i];
                var pipeInstance = (Pipe)Activator.CreateInstance(pipeType, finalAction);

                // Set the next action for the current pipe
                finalAction = pipeInstance.Handle;
            }

            // Execute the final action, which is the first pipe in the chain
            finalAction(httpContext);

            return this;
        }


        //public PipeBuilder Build(HttpContext httpContext)
        //{
        //    Action<HttpContext> pipeline = null;
        //    Pipe pipeInstance = null;

        //    for (int i = pipes.Count - 1; i >= 0; i--)
        //    {
        //        var type = pipes[i];

        //        var constructor = type.GetConstructor(new[] { typeof(Action<HttpContext>) });

        //        pipeInstance = (Pipe)constructor.Invoke(new[] { pipeline });

        //        pipeline = pipeInstance.Handle;

        //        builtPipes.Add(pipeInstance);

        //    }

        //    //pipeInstance.Handle(httpContext);

        //    var bp = builtPipes.FirstOrDefault();
        //    bp.Handle(httpContext);

        //    return this;
        //}






        //some other failed tries :D

        //public  PipeBuilder Build(HttpContext httpContext)
        //{
        //    Action<HttpContext> pipeline = context => { /* default request handling logic */ };

        //    for (int i = 0; i <= pipes.Count - 1; i++)
        //    {
        //        var currentPipeType = pipes[i];
        //        var nextPipeType = pipes[i+1];

        //        var currentConstructor = currentPipeType.GetConstructor(new[] { typeof(Action<HttpContext>) });
        //        var currentPipeInstance = (Pipe)currentConstructor.Invoke(new [] { pipeline });


        //        var nextConstructor = nextPipeType.GetConstructor(new[] { typeof(Action<HttpContext>) });
        //        var nextPipeInstance = (Pipe)nextConstructor.Invoke(new[] { pipeline });


        //        pipeline = pipeInstance.Handle;
        //    }

        //    pipeline(httpContext);
        //    return this;
        //}



    }
}
