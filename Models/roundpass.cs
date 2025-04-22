namespace CampusCraft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("roundpass")]
    public partial class roundpass
    {
        [Key]
        public int rp_ID { get; set; }

        public int stdID { get; set; }

        public int compID { get; set; }

        [Required]
        [StringLength(500)]
        public string which_round_they_pass { get; set; }

        public virtual company company { get; set; }
    }
}
