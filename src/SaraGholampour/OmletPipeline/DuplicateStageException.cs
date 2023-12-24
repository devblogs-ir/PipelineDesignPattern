namespace OmletPipeline;

public class DuplicateStageException:Exception
{
    public DuplicateStageException() : base("you pass this Stage !")
    {
    }
}
