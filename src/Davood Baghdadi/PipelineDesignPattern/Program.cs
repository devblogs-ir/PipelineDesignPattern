using Dumpify;
using System.Runtime;

namespace PipelineDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Framework framework = new Framework();

            Controller controller = new Controller();

            HTTPContext context = new HTTPContext();

            Console.WriteLine("Type your country name (iran,usa) : ");
            context.IP = Console.ReadLine();

            Console.WriteLine("Type your useId (1 or something else) : ");
            context.UserId = int.Parse(Console.ReadLine());

            Console.WriteLine("What do you need? (product or order) : ");
            context.Destination = Console.ReadLine();

            Action<HTTPContext> endPoint = controller.Get;

            framework.ExceptionHandling(context, context =>
                framework.AuthenticationHandling(context, context=> 
                framework.RoutingHandling(context,controller.Get)));
        }
    }
}
