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

        // Navigation property
        public ICollection<ReservationDetail> ReservationDetail { get; set; }
    }
}