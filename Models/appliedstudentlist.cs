namespace CampusCraft.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("appliedstudentlist")]
    public partial class appliedstudentlist
    {
        [Key]
        public int apply_ID { get; set; }

        [ForeignKey("student")]
        public int studentinfo { get; set; }

        [ForeignKey("company")]
        public int companyinfo { get; set; }

        public virtual company company { get; set; }
        public virtual student student { get; set; }
    }
}
