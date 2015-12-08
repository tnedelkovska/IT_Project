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
    [Authorize]
    public class ReservationController : ApiController
    {
        private ApartmentsContext db = new ApartmentsContext();

        // GET api/Default1
        public IEnumerable<Reservation> GetReservations()
        {
            return db.Reservations.Where(o => o.Customer == User.Identity.Name);
        }

        // GET api/Default1/5
        public Reservation GetReservation(int id)
        {
            Reservation reservation = db.Reservations.Include("ReservationDetails.Reservation")
            .First(o => o.Id == id && o.Customer == User.Identity.Name);
            if (reservation == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return reservation;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != reservation.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(reservation).State = EntityState.Modified;

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

        // POST api/Default1
        public HttpResponseMessage PostReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, reservation);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = reservation.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Reservations.Remove(reservation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}