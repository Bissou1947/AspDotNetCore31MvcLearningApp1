using System.Collections.Generic;

namespace BookStoreWeb.Models
{
    public class TestMailOptionsVM
    {
        public List<string> mailToAddresses { get; set; }
        public string mailSubject { get; set; }
        public string mailObject { get; set; }

        //....to send dynamic name in mail
        public List<KeyValuePair<string,string>> placeHolder { get; set; }
    }
}
