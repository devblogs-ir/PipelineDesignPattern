﻿using PipelineDesignPattern.Framework;

startProgram:
string strUrl = string.Empty;
string strIP = string.Empty;
var UrlArray = new string[] { "localhost/api/User/GetAll",
                              "localhost/api/Product/GetAll",
                              "localhost/api/Product/GetById" };


Console.WriteLine("List of available APIs:");
Console.WriteLine("0 => Enter the url manually!");
for (int i=1; i <= UrlArray.Length; i++)
    Console.WriteLine($"{i} => {UrlArray[i-1]}");

Console.WriteLine("---------------------------------------");
Console.WriteLine("Enter URL Number :");
byte urlNumber;
bool getUrl = byte.TryParse(Console.ReadLine(), out urlNumber);
if (getUrl == false)
{
    Console.WriteLine("Please run the program again and enter the correct value!");
    return;
}

if (urlNumber > UrlArray.Length)
{
    Console.WriteLine("Please enter the correct value!");
    Console.WriteLine("---------------------------------------");
    goto startProgram;
}

if (urlNumber == 0)
{
    Console.WriteLine("Enter your URL:");
    strUrl = Console.ReadLine();
}
else
    strUrl = UrlArray[urlNumber - 1];

Console.WriteLine("Enter your Ip:");
strIP = Console.ReadLine();


Framework framework = new(); 

// Request by USA
HttpContext httpContext2 = new() { IP = strIP, Url = strUrl };
framework.ExceptionHandeling(httpContext2, (context) => framework.Authentication(context, 
                                           (context) => framework.EndPointHanling(context, null!)));
