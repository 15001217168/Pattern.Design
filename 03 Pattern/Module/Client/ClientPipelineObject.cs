namespace _03_Pattern.Module.Client
{
    using Entity;

    public delegate void ClientPipelingObjectModules(Request request);
    public class ClientPipelineObject
    {
        public static ClientPipelineObject Config = new ClientPipelineObject();

        private ClientPipelingObjectModules modules;
        public ClientPipelineObject AddModule(ClientPipelingObjectModules module)
        {
            modules += module;
            return this;
        }
        public void RunPipeline(Request request)
        {
            modules(request);
        }
    }
}
