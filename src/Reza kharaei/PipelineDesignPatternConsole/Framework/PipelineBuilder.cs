
using PipelineDesignPatternConsole.Models;

namespace PipelineDesignPatternConsole.Framework;

public class PipelineBuilder()
{ 
     private List<Type> _pipes = new List<Type>();

     public PipelineBuilder AddPipe(Type pipe)
     {
        _pipes.Add(pipe);
        return this;
     }

    public PipelineBuilder Build(HttpContext httpContext)
    {
        for (int i = _pipes.Count - 1; i >= 0; i--)
        {
            var pipeInstance = Activator.CreateInstance(_pipes[i]);
            var handlerMethod = _pipes[i].GetMethod("Handler");  
            if (handlerMethod is not null)
                handlerMethod.Invoke(pipeInstance, new [] { httpContext } );
        }

        return this;
    }
}