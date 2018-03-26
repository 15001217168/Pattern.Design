namespace _03_Pattern
{
    using Entity;
    public class OperationLogicPipelineObjectFactory
    {
        public static IBuildOperationLogicPipelineObject Create(RequestClientType type)
        {
            if (type.type == RequestClientType.App)
            {
                return new ClientFotAppType();
            }
            return null;
        }
    }
}
