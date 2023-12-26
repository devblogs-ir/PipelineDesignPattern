namespace OmletPipeline;

public class IncorrectStageException:Exception
{
    public IncorrectStageException(string stage) : base($" {stage} is incorrect .try again. ")
    {
    }

}
