using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using PipelineDesignPattern.Exceptions;
using PipelineDesignPattern.Pipes;
namespace PipelineDesignPattern;
public class Framework
{
    //public void Authentication(HttpContext httpContext, Action<HttpContext> action)
    //{
    //    Console.WriteLine("starting Auth");
    //    if (httpContext is null)
    //        throw new IPNotProvideException("IP is not provided");
    //    else if (httpContext.IP is "85.185.20.177")
    //        throw new InvalidIPException("invalid IP");

    //    action(httpContext);
    //}
    //public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
    //{
    //    Console.WriteLine("starting except");
    //    try
    //    {
    //        action(httpContext);
    //    }
    //    catch (Exception ex) when (ex is IPNotProvideException)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }
    //    catch (Exception ex) when (ex is InvalidIPException)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }
    //} 
    //public void EndpointHandling(HttpContext httpContext, Action<HttpContext> action)
    //{
    //    var parts = httpContext.Url.Split('/');
    //    var controllerClass = parts[1];
    //    var actionMethod = parts[2];
    //    var userId = parts[3];
    //    var templateControllerName = $"PipelineDesignPattern.{controllerClass}Controller";
    //    var typeController = Type.GetType(templateControllerName);
    //    MethodInfo method = typeController.GetMethod(actionMethod);
    //    var parametersInfo = method.GetParameters();

    //    var userIdAsInt = Convert.ChangeType(userId, parametersInfo[0].ParameterType);


    //    var instance = Activator.CreateInstance(typeController, new[] {httpContext});
    //    //var productsController = instance as ProductsController;

    //    method.Invoke(instance, new[] { userIdAsInt });


    //}


    public class PipelineBuilder
    {
        private List<Type> _pipes = new List<Type>();
        public PipelineBuilder AddPipe<TType>()
        {
            _pipes.Add(typeof(TType));
            return this;
        }
        public Action<HttpContext> build()
        {
            var currentPipe = (Pipe)Activator.CreateInstance(_pipes[_pipes.Count - 1], null);
            for (int index = _pipes.Count - 2; index > 0; index--)
            {
                currentPipe = (Pipe)Activator.CreateInstance(_pipes[index], new[] { currentPipe });
            }

            var firstPipe = (Pipe)Activator.CreateInstance(_pipes[0], currentPipe.Handle);
            return firstPipe.Handle;
        }

    }
}