using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.DateTime)]
        //public string MyField { get; set; }

        public int Id { get; set; }
        //[StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="Please Enter Title For Book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter Author For Book")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Total Pages For Book")]
        [Display(Name ="Total Pages")]
        public int TotalPages { get; set; }
        [Required(ErrorMessage ="Please Choose Language")]
        public string Language { get; set; }
    }
}
