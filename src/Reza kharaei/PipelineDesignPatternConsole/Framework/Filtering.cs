namespace PipelineDesignPatternConsole.Framework;

public class Filtering()
{
    public bool IsValid(string IP)
    {
        if (string.IsNullOrEmpty(IP))
            throw new Exception("Your IP Address is not accessible");

        if (IP.StartsWith("98."))
            return false;

        return true;
    }
}