using Dumpify;
using System.Reflection;

namespace PipelineDesignPattern.Pipes
{
    public class EndPointPipe : Pipe
    {
        public EndPointPipe(Action<HTTPContext> next) : base(next)
        {

        }
        public override void Handle(HTTPContext context)
        {
            Console.WriteLine("a request recieved from " + context.IP.ToString());
            var urlParts = context.Url.Split('/');
            var controllerName = urlParts[1] + "Controller";
            var actionMethod = urlParts[2];
            //Get All Controllers in controller folder
            var controllersList = Assembly.GetExecutingAssembly().GetTypes()
                                 .Where(t => t.Namespace == "PipelineDesignPattern.Controllers");

            Type controllerType = null;
            MethodInfo method = null;

            //looking for called controller in contollers list
            try
            {
                if (controllersList.Any(t => t.Name.ToLower() == controllerName.ToLower()))
                {
                    controllerType = controllersList.FirstOrDefault(t => t.Name.ToLower() == controllerName.ToLower());
                }
                else
                {
                    throw new NotFoundUrlException();
                }

                //looking for called action in methodes list of contoller
                if (controllerType.GetMethods().Any(m => m.Name.ToLower() == actionMethod.ToLower()))
                {
                    method = controllerType.GetMethods().FirstOrDefault(m => m.Name.ToLower() == actionMethod.ToLower());
                    var controllerInstance = Activator.CreateInstance(controllerType, new object[] { context });
                    method.Invoke(controllerInstance, null);
                }
                else
                {
                    throw new NotFoundUrlException();
                }
            }
            catch (NotFoundUrlException ex)
            {
                (ex.Message + "Please Check Route Data").Dump();
            }
            finally
            {
                if (_next is not null)
                    _next(context);
            }

        }
    }
}
