namespace OmletPipeline;

public class InvalidStageException:Exception
{
    public InvalidStageException(string stage) : base($"{stage} is inValid, think more .")
    {
    }
}
