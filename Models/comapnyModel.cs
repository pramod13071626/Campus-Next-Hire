namespace CampusCraft.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class comapnyModel : DbContext
    {
        public comapnyModel()
            : base("name=comapnyModel")
        {
        }

        public virtual DbSet<company> companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<company>()
                .Property(e => e.cmpname)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.job_description)
                .IsUnicode(false);
        }
    }
}
