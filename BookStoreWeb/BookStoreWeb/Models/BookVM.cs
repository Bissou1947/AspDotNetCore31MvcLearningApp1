using BookStoreWeb.CustomValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class BookVM
    {
        public int id { get; set; }
        [Required]
        [StringLength(100,MinimumLength = 3)]
        [Display(Name = "Title")]
        //[MyCustomValidation("mvc",ErrorMessage ="waw")]  //... test custom validation ...//
        public string title { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Author")]
        public string author { get; set; }
        [StringLength(500, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Page")]
        [Range(maximum:3000,minimum: 20)]
        public int? page { get; set; }
        [Display(Name = "Category")]
        public string category { get; set; }
        [Required]
        [Display(Name = "Language")]
        public int? languageId { get; set; }
        public string languageName { get; set; }
        [Display(Name = "Create Date")]
        public DateTime? creatDate { get; set; }
        [Display(Name = "Update Date")]
        public DateTime? updateDate { get; set; }


        //....cover photo for book
        [Required]
        [Display(Name = "Cover Photo")]
        public IFormFile bookCoverPhoto { get; set; }
        public string bookCoverPhotoPathToDB { get; set; }

        //....Gallery photos for book
        [Required]
        [Display(Name = "Gallery Photos")]
        public IFormFileCollection bookGalleryPhotos { get; set; }
        public List<GalleryVM> galleryVm { get; set; }

        //....pdf for book
        [Required]
        [Display(Name = "PDF")]
        public IFormFile bookPDF { get; set; }
        public string bookPDFPathToDB { get; set; }

    }
}
