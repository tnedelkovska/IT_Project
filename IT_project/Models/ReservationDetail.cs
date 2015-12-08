using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_project.Models
{
    public class ReservationDetail
    {

        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Navigation properties
        public Apartment Apartment { get; set; }
        public Reservation Reservation { get; set; }

    }
}