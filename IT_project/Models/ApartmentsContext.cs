using System.Collections.Generic;
using System.Data.Entity;

namespace IT_project.Models
{
    public class ApartmentsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<IT_project.Models.ApartmentsContext>());

        public ApartmentsContext() : base("name=ApartmentsContext")
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }



}
