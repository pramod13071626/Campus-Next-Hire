namespace CampusCraft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class placed_student_list
    {
        [Key]
        public int place_ID { get; set; }

        public int stdID { get; set; }

        public int compID { get; set; }

        public virtual company company { get; set; }
    }
}
