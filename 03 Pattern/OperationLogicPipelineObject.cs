namespace _03_Pattern
{
    using Entity;
    /// <summary>
    /// 管道中的Module引用
    /// </summary>
    /// <param name="request"></param>
    public delegate void OperationLogicPipelineObjectModules(Request request);
    /// <summary>
    /// 处理逻辑管道对象
    /// </summary>
    public class OperationLogicPipelineObject
    {
        private OperationLogicPipelineObjectModules _modules;

        internal void Add(OperationLogicPipelineObjectModules module)
        {
            this._modules += module;
        }

        public void RunPipeline(Request request)
        {
            this._modules(request);
        }
    }
}
