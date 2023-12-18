namespace PipelineDesignPattern.SimpleImplement.Pipeline
{
    public class Pipeline
    {
        readonly IPipelineContext _context;
        IPipelineStep _startPoint;
        public Pipeline(IPipelineContext context)
        {
            _context = context;
        }
        public void SetStartProccessPoint(IPipelineStep startPointStep)
        {
            _startPoint = startPointStep;
        }
        public void ExecutePipeline()
        {
            _startPoint.Exceute(_context);
        }
    }
}
