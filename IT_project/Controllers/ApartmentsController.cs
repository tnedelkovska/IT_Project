using IT_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IT_project.Controllers
{
    public class ApartmentsController : ApiController
    {
        private ApartmentsContext db = new ApartmentsContext();

        // Project products to product DTOs.
        private IQueryable<Apartment> MapApartments()
        {
            return from p in db.Apartments select p;
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return MapApartments().AsEnumerable();
        }

        public Apartment GetApartment(int id)
        {
           
            return db.Apartments.Find(id);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
