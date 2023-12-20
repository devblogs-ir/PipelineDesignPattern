using System;
namespace PipelineDesignPattern;

    public class CountryBlockedException : Exception
    {
        public CountryBlockedException() : base() { }

        public CountryBlockedException(string message) : base(message) { }

        public CountryBlockedException(string message, Exception innerException) : base(message, innerException) { }
    }
