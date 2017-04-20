using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in stock")]
        [StockGratterThan0]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Action { get; set; }

        public MovieFormViewModel(Movies Movie)
        {
            id = Movie.id;
            name = Movie.name;
            ReleaseDate = Movie.ReleaseDate;
            NumberInStock = (byte) Movie.NumberInStock;
            GenreId = Movie.GenreId;
        }

        public MovieFormViewModel()
        {
            id = 0;
        }
    }
}