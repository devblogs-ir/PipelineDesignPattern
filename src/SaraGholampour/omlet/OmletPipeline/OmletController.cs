namespace OmletPipeline;

public class OmletController
{

    public string ValidateStage(Func<string> func,List<string> cookLine,List<string> instructions)
    {
        try
        {
            var result = func();
                 
            if ( cookLine.Contains(result))
            {
                throw new DuplicateStageException();
            }
            else if (!instructions.Contains(result))
            {
                throw new IncorrectStageException(result);
            }
            else
            {
                if (instructions[cookLine.Count]== result)
                {
                    
                  return result;
                }

                else throw new IncorrectStageException(result);

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e?.Message);
          return ValidateStage(func,cookLine,instructions);
        }


    }
    public string GetStage()
    {
        Console.WriteLine("Enter Your Idea");
       var answer= Console.ReadLine();
       return answer;
    }


    public void SaveStage(Func<string> func,List<string> cookLine)
    {
             var result=func();
            cookLine.Add(result);
            Console.WriteLine("your right , continue ...");
                 
    }

}
