namespace _03_Pattern.Entity
{
    using System.Text;
    public class Request
    {
        public StringBuilder Head { get; set; }
        public RequestClientType ClientType { get; set; }
        public RequestContent Content { get; set; }
    }
}
