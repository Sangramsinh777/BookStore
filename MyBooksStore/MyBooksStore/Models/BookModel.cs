using Microsoft.AspNetCore.Http;
using MyBooksStore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Title For Book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter Author For Book")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Total Pages For Book")]
        [Display(Name ="Total Pages")]
        public int TotalPages { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Display(Name ="Upload Cover Photo")]
        [Required(ErrorMessage ="Please upload cover photo")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
