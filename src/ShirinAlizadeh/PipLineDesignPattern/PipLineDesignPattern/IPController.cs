using ConsoleDump;
using System.Collections;

namespace PipLineDesignPattern
{
    public class IpController
    {


        public string GetIpByIdUser(HttpContext ip)
        {
            var result = GetAllIP();
            var response = result.Where(x=> Country.iPUsa.Contains(ip.IPIdUser)).FirstOrDefault();
            return response.IPUsa;
        }

        public List<IPContery> GetAllIP()
        {
            IPContery iPContery=new IPContery();
            var ListOfIp = new List<IPContery>()
            {
                 new IPContery
                 {
                 
                     IPIran= $"IPIran :   {Country.iPIran}.120.0.0",
                     IPUsa= $"IPUsa :    {Country.iPUsa}.120.0.0"
                 }
            };
         
        Console.WriteLine(
                    $"IP Of Contries \n" +
             
                    $"IPIran :  {Country.iPIran}.120.0.0\n" +
   
                    $"IPUsa :    {Country.iPUsa}.120.0.0\n" 
  
                    );
            return ListOfIp;

        }
    }
}
