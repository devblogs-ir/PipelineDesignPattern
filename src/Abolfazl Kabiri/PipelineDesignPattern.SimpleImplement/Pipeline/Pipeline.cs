namespace PipelineDesignPattern.SimpleImplement.Pipeline
{
    internal class Pipeline
    {
        readonly List<IPipelineStep> _steps;
        public Pipeline()
        {
            _steps = new List<IPipelineStep>();
        }

        void AddStep(IPipelineStep step)
        {
            _steps.Add(step);
        }
        void ExecutePipeline()
        {
            foreach (var step in _steps)
            {
                //step.Exceute();
            }
        }
    }
}
