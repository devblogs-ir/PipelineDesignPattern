using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using static PipelineDesignPattern.Framework;

namespace PipelineDesignPattern;

public class PipeLineBuilder()
{
    private List<Action<HttpContext>> _pipe = new List<Action<HttpContext>>();


    public PipeLineBuilder AddPipe(Action<HttpContext> pipe)
    {
        _pipe.Add(pipe);
        return this;
    }

    public PipeLineBuilder  Build(HttpContext context)
    {
        _pipe[0].Invoke(context);
         return this;
    }

   
}
