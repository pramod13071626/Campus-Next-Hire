using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CampusCraft.Models
{
    public partial class rolesModel : DbContext
    {
        public rolesModel()
            : base("name=rolesModel")
        {
        }

        public virtual DbSet<roles_tbl> roles_tbl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<roles_tbl>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<roles_tbl>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<roles_tbl>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
