namespace LoginAPI_Tutorial.Models
{

    public class OTPEmail
    {
        public Sender Sender { get; set; }
        public List<To> To { get; set; }
        public string Subject { get; set; }
        public string HtmlContent { get; set; }
    }

    public class Sender
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class To
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}

