using eCommerceTest.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceTest.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "URL Required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Name required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
