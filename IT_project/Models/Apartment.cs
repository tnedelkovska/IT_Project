using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_project.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Apartment
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

    }
}