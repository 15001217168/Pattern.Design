namespace _03_Pattern
{
    using System;
    using _03_Pattern.Entity;

    public class ClientFotAppType : IBuildOperationLogicPipelineObject
    {
        public OperationLogicPipelineObject BuildOperationPipeline(Request request)
        {
            var result = new OperationLogicPipelineObject();

            result.Add(requestObjec =>
            {
                

            });

            return result;
        }
    }
}
