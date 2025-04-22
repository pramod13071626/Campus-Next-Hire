namespace CampusCraft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student")]
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            appliedstudentlists = new HashSet<appliedstudentlist>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stdID { get; set; }

        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string course { get; set; }

        [Required]
        [StringLength(150)]
        public string year { get; set; }

        [Required]
        [StringLength(150)]
        public string email { get; set; }

        [Required]
        [StringLength(150)]
        public string mobile { get; set; }

        [Column(TypeName = "image")]
        public byte[] add_resume { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appliedstudentlist> appliedstudentlists { get; set; }
    }
}
