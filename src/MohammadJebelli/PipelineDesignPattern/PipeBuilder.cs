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

        public PipeBuilder Build(HttpContext httpContext)
        {
            Action<HttpContext> pipeline = null;

            //for (int i = 0; i <= pipes.Count - 1; i++)
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                var type = pipes[i];

                var instance = Activator.CreateInstance(type, pipeline);

                var constructor = type.GetConstructor(new[] { typeof(Action<HttpContext>) });

                var pipeInstance = (Pipe)constructor.Invoke(new[] { pipeline });

                pipeline = pipeInstance.Handle;

                if(i == 0)
                {
                    pipeInstance.Handle(httpContext);
                }
            }
            
            

            return this;
        }

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
