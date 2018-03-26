namespace _03_Pattern
{
    using Entity;
    /// <summary>
    /// 生成逻辑处理管道接口
    /// </summary>
    public interface IBuildOperationLogicPipelineObject
    {
        OperationLogicPipelineObject BuildOperationPipeline(Request request);
    }
}
