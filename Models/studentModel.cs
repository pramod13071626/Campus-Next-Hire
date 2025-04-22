using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CampusCraft.Models
{
    public partial class studentModel : DbContext
    {
        public studentModel()
            : base("name=studentModel")
        {
        }

        public virtual DbSet<student> students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.course)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.mobile)
                .IsUnicode(false);
        }
    }
}
