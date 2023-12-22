namespace OmletPipeline;

public class OmletController
{
    public string validateStage(OAction func)
    {
        try
        {
            var result = func();
                 
            if ( OmletContext.cookLine.Contains(result))
            {
                throw new DuplicateStageException();
            }
            else if (!OmletContext.instructions.Contains(result))
            {

                throw new IncorrectStageException(result);
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            validateStage(func);
        }

        return "";

    }
    public string getStage()
    {
        Console.WriteLine("Enter Your Idea");
        var ans= Console.ReadLine();
        return ans;
    }

   public delegate string OAction();

    public void saveStage(OAction func)
    {
        try
        {
             var result=func();
            OmletContext.cookLine.Add(result);
            Console.WriteLine("your right , continue ...");

        }
        catch (Exception e)
        {
            // Console.WriteLine(e);
            
            saveStage(func);
        }

    }

    public delegate void OO();
    public void handleOmletCycle(OO cycle)
    {
       
            try
            {
                cycle();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

    }
}
