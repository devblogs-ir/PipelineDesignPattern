
using OmletPipeline;


OmletController omletPipe = new();
OmletContext omlet = new();



while (omlet.cookLine.Count!= omlet.instructions.Count)
{
    
omletPipe.SaveStage(()=>omletPipe.ValidateStage(omletPipe.GetStage,omlet.cookLine,omlet.instructions),omlet.cookLine);
}
if (omlet.instructions.Count== omlet.instructions.Count)
{
    Console.WriteLine("congrats . we cook omlet successfully");
}
