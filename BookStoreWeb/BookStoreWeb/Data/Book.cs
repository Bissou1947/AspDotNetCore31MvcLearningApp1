using System;
using System.Collections.Generic;

namespace BookStoreWeb.Data
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public int? page { get; set; }
        public string category { get; set; }
        public int? languageId { get; set; }
        public DateTime? creatDate { get; set; }
        public DateTime? updateDate { get; set; }
        public string coverPhotoPath { get; set; }
        public string pdfPath { get; set; }

        //.....relations............//
        public Language Language { get; set; }
        public ICollection<Gallery> Gallery { get; set; }
    }
}
