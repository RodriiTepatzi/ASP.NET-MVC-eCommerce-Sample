﻿using eCommerceTest.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceTest.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Category")]
        public MovieCategory MovieCategory { get; set; }

        //Relationship

        public List<Actor_Movie> Actors_Movies { get; set; }
        
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }
}
