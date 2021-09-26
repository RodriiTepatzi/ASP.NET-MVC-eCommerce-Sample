using eCommerceTest.Data;
using eCommerceTest.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceTest.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Movie description is required")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Movie price is required")]
        public double Price { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Movie image is required")]
        public string Image { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
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
