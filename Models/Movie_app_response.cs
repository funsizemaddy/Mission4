using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class Movie_app_response
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        //Builds the foreign key relationship to the othe category table
        [Required(ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        [Required(ErrorMessage ="Did you forget to enter a movie title?")]
        public string Title { get; set; }

        [Required(ErrorMessage ="What was the director's name again?")]
        public string Director { get; set; }

        [Required(ErrorMessage="Please enter the year the movie was made.")]
        public short Year { get; set; }

        [Required(ErrorMessage ="Please select a rating from the drop down. ")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string Lent { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
