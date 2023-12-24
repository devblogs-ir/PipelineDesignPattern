
using OmletPipeline;


OmletController omletPipe = new();
OmletContext omlet = new();



while (omlet.CookLine.Count!= omlet.Instructions.Count)
{
    
omletPipe.SaveStage(()=>omletPipe.ValidateStage(omletPipe.GetStage,omlet.CookLine,omlet.Instructions),omlet.CookLine);
}
if (omlet.Instructions.Count== omlet.Instructions.Count)
{
    Console.WriteLine("congrats . we cook omlet successfully");
}
