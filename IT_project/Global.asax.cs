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

            
            //Database.SetInitializer<ApartmentsContext>(new DropCreateDatabaseIfModelChanges<ApartmentsContext>());

            //using (var context = new ApartmentsContext())
            //{
            //    context.Database.Initialize(force: true);
            //}
            //Seed();
        }

        private static void Seed()
        {
            ApartmentsContext context = new ApartmentsContext();

            var apartments = new List<Apartment>()            
            {
                new Apartment() { Name = "Villa Lucija",Description = "Offering a sun terrace and a private beach area, House Lucija is set in Ohrid, 300 metres from Ancient Theatre of Ohrid.  Some units have a private bathroom with a hot tub, while others have slippers and free toiletries. Some rooms feature a seating area for your convenience. A balcony or patio are featured in certain rooms. House Lucija features free WiFi .  You will find a tour desk at the property.  This guest house has water sports facilities and bike hire is available. Guests can enjoy various activities in the surroundings, including cycling, fishing and hiking. The nearest airport is Ohrid Airport, 9 km from Villa ucija.   We speak your language!",Rooms = 5,ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/02/24/b1/a4/villa-lucija.jpg"},
                new Apartment() { Name = "Villa White Lake ",Description = "Set in Ohrid, Villa White Lake is 1 km from Ancient Theatre of Ohrid. Samoil's Fortress is 1.2 km from the property. Free WiFi is available throughout the property.  All units include a flat-screen TV with cable channels. Some units feature a terrace and/or balcony. A refrigerator and kettle are also provided. Some units also have a kitchenette, equipped with a stovetop. Every unit is fitted with a private bathroom with a shower and a hair dryer.  The nearest airport is Ohrid Airport, 9 km from the property.   We speak your language!",Rooms = 5,ImageUrl = "https://geo3.ggpht.com/cbk?panoid=ZL0U9HOGpq0BKmMsDmoD2w&output=thumbnail&cb_client=search.LOCAL_UNIVERSAL.gps&thumb=2&w=227&h=160&yaw=49.174725&pitch=0"},
                
            };

            apartments.ForEach(p => context.Apartments.Add(p));
            context.SaveChanges();

        }
    }
}