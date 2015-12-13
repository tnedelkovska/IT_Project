using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_project.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public string Customer { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }

        public int ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}