namespace CampusCraft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("company")]
    public partial class company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public company()
        {
            appliedstudentlists = new HashSet<appliedstudentlist>();
            placed_student_list = new HashSet<placed_student_list>();
            roundpasses = new HashSet<roundpass>();
        }

        [Key]
        public int compID { get; set; }

        [Required]
        [StringLength(150)]
        public string cmpname { get; set; }

        [Required]
        [StringLength(150)]
        public string location { get; set; }

        public string job_requirements { get; set; }

        [Required]
        [StringLength(1000)]
        public string job_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appliedstudentlist> appliedstudentlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<placed_student_list> placed_student_list { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<roundpass> roundpasses { get; set; }
    }
}
