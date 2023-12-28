﻿using PipelineDesignPattern.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern.Pipes
{
    public class ExceptionHandlingPipe : Pipe
    {
        public ExceptionHandlingPipe()
        {
            _next = null!;
        }
        private Action<HttpContext> _next;

        public override void Handle(HttpContext httpContext)
        {
            Console.WriteLine("starting except...");
            try
            {
                if (_next != null)
                    _next(httpContext);
            }
            catch (Exception ex) when (ex is IPNotProvideException)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) when (ex is InvalidIPException)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
