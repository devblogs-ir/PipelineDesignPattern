namespace PipelineDesignPattern;
    public class BannedIPException : ApplicationException
    {
        public BannedIPException(string ip) :
            base($"{ip} is banned!")
        {

        }
    }
