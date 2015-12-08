using IT_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IT_project
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Seed();
            Database.SetInitializer<ApartmentsContext>(new DropCreateDatabaseIfModelChanges<ApartmentsContext>());

            //using (var context = new ApartmentsContext())
            //{
            //    context.Database.Initialize(force: true);
            //}

        }

        private static void Seed()
        {
            ApartmentsContext context = new ApartmentsContext();

            var apartments = new List<Apartment>()            
            {
                new Apartment() { Name = "Apartment 1"},
                new Apartment() { Name = "Apartment 2"},
                new Apartment() { Name = "Apartment 3"}
            };

            apartments.ForEach(p => context.Apartments.Add(p));
            context.SaveChanges();

            var reservation = new Reservation() { Customer = "Dummy" };
            var rd = new List<ReservationDetail>()
            {
                new ReservationDetail() { Apartment = apartments[0],Reservation = reservation,From = DateTime.Now,To = DateTime.Now.AddDays(10)},
                new ReservationDetail() { Apartment = apartments[1],Reservation = reservation,From = DateTime.Now,To = DateTime.Now.AddDays(10)}
            };
            context.Reservations.Add(reservation);
            rd.ForEach(o => context.ReservationDetails.Add(o));

            context.SaveChanges();
        }
    }
}