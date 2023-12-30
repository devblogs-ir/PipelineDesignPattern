using PipelineDesignPattern.Pipelines;

namespace PipelineDesignPattern.Builders;

/// <summary>
/// using builder pattern tp simplify creating objects 
/// </summary>
public class PipelineBuilder(List<HttpContext> httpContexts)
{
    private List<Type> _pipes = new List<Type>();

    public PipelineBuilder AddPipe(Type pipe)
    {
        _pipes.Add(pipe);
        return this;

    }

    public void Build()
    {
        // Create an instance of the desired type
        foreach (HttpContext httpContext in httpContexts)
        {
            foreach (Type pipeType in _pipes)
            {
                Action<HttpContext> httpContextAction = (httpContext) => { };

                var instance = Activator.CreateInstance(pipeType, httpContextAction);

                switch (instance)
                {
                    case ExceptionHandlingPipe exceptionHandlingPipe:
                        exceptionHandlingPipe.Handle(httpContext);
                        break;
                    case AuthenticationPipe authenticationPipe:
                        authenticationPipe.Handle(httpContext);
                        break;
                    case EndPointPipe endPointPipe:
                        endPointPipe.Handle(httpContext);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
