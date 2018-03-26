namespace _03_Pattern
{
    using System.Text;
    using Entity;
    using Module.Client;
    public class PatternTest
    {
        public static void Test()
        {
            Request request = new Request()
            {
                Content = new RequestContent() { Content = "Query order method" },
                Head = new StringBuilder(),
                ClientType = RequestClientTypeFactory.CreateRequestClientTypeForNet()
            };
            ClientPipelineObject.Config.AddModule(ClientPipelineModules.CheckRequestContent).AddModule(ClientPipelineModules.AddRequestHead).AddModule(ClientPipelineModules.TransferRequestFormat).AddModule(ClientPipelineModules.ReduceRequest);
            ClientPipelineObject.Config.RunPipeline(request);
            string content = request.Content.Content;
        }
    }
}
