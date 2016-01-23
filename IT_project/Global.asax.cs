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
                new Apartment() { Name = "Villa Lucija",Description = "Offering a sun terrace and a private beach area, House Lucija is set in Ohrid, 300 metres from Ancient Theatre of Ohrid.  Some units have a private bathroom with a hot tub, while others have slippers and free toiletries. Some rooms feature a seating area for your convenience. A balcony or patio are featured in certain rooms. House Lucija features free WiFi .  You will find a tour desk at the property.  This guest house has water sports facilities and bike hire is available. Guests can enjoy various activities in the surroundings, including cycling, fishing and hiking. The nearest airport is Ohrid Airport, 9 km from Villa Lucija.   We speak your language!",Rooms = 5,ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/02/24/b1/a4/villa-lucija.jpg"},
                new Apartment() { Name = "Villa White Lake ",Description = "Set in Ohrid, Villa White Lake is 1 km from Ancient Theatre of Ohrid. Samoil's Fortress is 1.2 km from the property. Free WiFi is available throughout the property.  All units include a flat-screen TV with cable channels. Some units feature a terrace and/or balcony. A refrigerator and kettle are also provided. Some units also have a kitchenette, equipped with a stovetop. Every unit is fitted with a private bathroom with a shower and a hair dryer.  The nearest airport is Ohrid Airport, 9 km from the property.   We speak your language!",Rooms = 5,ImageUrl = "https://geo3.ggpht.com/cbk?panoid=ZL0U9HOGpq0BKmMsDmoD2w&output=thumbnail&cb_client=search.LOCAL_UNIVERSAL.gps&thumb=2&w=227&h=160&yaw=49.174725&pitch=0"},
                //new Apartment() { Name="Villa Kale",Description="Vila Kale is a lovely new facility, designed and decorated in a traditional, authentic style. It fascinates with its appearance and dominant location in the heart of Ohrid's historic quarter. Wherever you look, there is a breathtaking view of Lake Ohrid, the historic quarter and the ancient theater. Upon request, visits and picnics on the shore of Lake Ohrid can be arranged. The hotel warmly invites you to be part of all the entertainment and cultural events held in the historic part of the city, where you will experience the true magic of Ohrid.",ImageUrl="http://bstatic.com/images/hotel/org/118/1184192.jpg"},
                //ew Apartment() { Name="Villa Mina",Description="Located directly on Lake Ohrid,Vila Mina offers a range of bright rooms and studio apartments with tiled floors and modern furniture. All rooms include hot drinks facilities, and some have a fully equipped kitchen. Many offer wonderful lake views.Breakfast is provided each morning. Snacks and drinks are served in Vila Mina's café-bar. Guests also have use of a shared kitchen, and can enjoy barbecues in the garden overlooking the lake and mountains.Secured private parking is available at the Vila Mina. Ohrid Airport is a 10-minute drive away, and the Monastery of Saint Naum is 30 minutes away.",ImageUrl="https://i.ytimg.com/vi/1doUwZtMvLU/maxresdefault.jpg"},
            };

            apartments.ForEach(p => context.Apartments.Add(p));
            context.SaveChanges();

        }
    }
}