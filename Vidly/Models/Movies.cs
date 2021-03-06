﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movies
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date added")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [StockGratterThan0]
        public int NumberInStock { get; set; }

        public Movies()
        {
            DateAdded = DateTime.Now;
        }

    }
}