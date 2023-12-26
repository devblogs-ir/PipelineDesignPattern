namespace PipeLineDesignPattern;

public class InvalidException:ApplicationException
{
    public InvalidException() : base("Invalid Ip"){}
}
