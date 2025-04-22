namespace CampusCraft.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CC : DbContext
    {
        public CC()
            : base("name=CC2")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<appliedstudentlist> appliedstudentlists { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<placed_student_list> placed_student_list { get; set; }
        public virtual DbSet<roles_tbl> roles_tbl { get; set; }
        public virtual DbSet<roundpass> roundpasses { get; set; }
        public virtual DbSet<student> students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.aname)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<company>()
                .Property(e => e.cmpname)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.job_description)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.appliedstudentlists)
                .WithRequired(e => e.company)
                .HasForeignKey(e => e.companyinfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.placed_student_list)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.roundpasses)
                .WithRequired(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<roles_tbl>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<roles_tbl>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<roles_tbl>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<roundpass>()
                .Property(e => e.which_round_they_pass)
                .IsUnicode(false);

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

            modelBuilder.Entity<student>()
                .HasMany(e => e.appliedstudentlists)
                .WithRequired(e => e.student)
                .HasForeignKey(e => e.studentinfo)
                .WillCascadeOnDelete(false);
        }
    }
}
