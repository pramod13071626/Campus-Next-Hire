namespace CampusCraft.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class appliedStudentListModel : DbContext
    {
        public appliedStudentListModel()
            : base("name=appliedStudentListModel")
        {
        }

        public virtual DbSet<appliedstudentlist> appliedstudentlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
