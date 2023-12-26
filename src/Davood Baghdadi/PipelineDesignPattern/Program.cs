using Dumpify;
using PipelineDesignPattern.Pipes;
using System.Reflection;
using System.Runtime;

namespace PipelineDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HTTPContext context = new()
            {
                IP = "127.0.0.1",
                Url = "localhost:4545/Order/GetAll"
            };

            


            Console.WriteLine("Type your url (like this: mysite/Product/GetAll ) (product or order) : ");
            context.Url = Console.ReadLine();


            Console.WriteLine("Where are you? (iran or usa) : ");
            context.IP = Console.ReadLine();


            var endPoint = new EndPointPipe(null);
            var authentication = new AuthenticationPipe(endPoint.Handle);
            var locationManger = new LocationManagmentPipe(authentication.Handle);

            locationManger.Handle(context);

            Console.ReadKey();
        }
    }
}
