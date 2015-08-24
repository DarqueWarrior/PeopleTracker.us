namespace PeopleTracker.DAL
{
   using System;
   using System.Data.Entity;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Linq;

   public partial class Models : DbContext
   {
      public Models()
          : base("name=Models")
      {
      }

      public virtual DbSet<Person> People { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
      }
   }
}
