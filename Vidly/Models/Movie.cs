using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Display(Name = "Genero")]
        public GenreType Genre { get; set;  }
        [Required]
        public int GenreTypeId { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
    }
}