namespace Ws4vn.Microservicess.ApplicationCore.Events
{
    public class EmailContentCreated
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
