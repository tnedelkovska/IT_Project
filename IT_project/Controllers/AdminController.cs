using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IT_project.Models;

namespace IT_project.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class AdminController : ApiController
    {
        private ApartmentsContext db = new ApartmentsContext();

        // GET api/Admin
        public IEnumerable<Apartment> GetApartments()
        {
            return db.Apartments.AsEnumerable().ToArray();
        }

        // GET api/Admin/5
        public Apartment GetApartment(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return apartment;
        }

        // PUT api/Admin/5
        public HttpResponseMessage PutApartment(int id, Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != apartment.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(apartment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Admin
        public HttpResponseMessage PostApartment(Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, apartment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = apartment.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Admin/5
        public HttpResponseMessage DeleteApartment(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Apartments.Remove(apartment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, apartment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}