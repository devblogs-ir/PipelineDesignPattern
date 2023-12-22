
using OmletPipeline;


OmletController omletPipe = new ();
ExceptionHandler framework = new();



while (OmletContext.cookLine.Count!= OmletContext.instructions.Count)
{
    
omletPipe.handleOmletCycle(()=>omletPipe.saveStage(()=>omletPipe.validateStage(omletPipe.getStage)));
}
if (OmletContext.cookLine.Count== OmletContext.instructions.Count)
{
    Console.WriteLine("congrats . we cook omlet successfully");
}
