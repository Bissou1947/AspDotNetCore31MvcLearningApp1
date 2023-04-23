namespace BookStoreWeb.Models
{
    public class SmtpConfigVM
    {
        public string SenderMail { get; set; }
        public string SenderName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
