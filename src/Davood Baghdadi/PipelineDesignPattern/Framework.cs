﻿using Dumpify;
using PipelineDesignPattern.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{

    public class Framework
    {
        public const string Iran = "iran";
        public void HandleLocationException(HTTPContext http, Action<HTTPContext> exeptionAction)
        {
            "considering IP Address...".Dump();
            try
            {
                if (http.IP is Iran)
                {
                    throw new GeoLocationException(Iran);
                }
                else
                    exeptionAction(http);
            }
            catch (GeoLocationException ex)
            {
                ex.Message.Dump();
            }
        }
        public void HandleAuthentication(HTTPContext http, Action<HTTPContext> authAction)
        {
            "Starting Authentication by userId...".Dump();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(".");
            }


            "Authentication Operation ends here!".Dump();
            authAction(http);
        }

        public void HandleEndpoint(HTTPContext context, Action<HTTPContext> routingAction)
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
            //routingAction(context);
        }
    }
}
