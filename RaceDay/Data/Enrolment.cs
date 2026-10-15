
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.Data
{
    [Table("Enrolment", Schema = "dbo")]
    public class Enrolment
    {
        [Key]
        public int EnrolmentID { get; set; }

        public int UserID { get; set; }

        [Column("CategoryID")]
        public int CategoryID { get; set; }

        [Column("EnrolmentDate")]
        public DateTime EnrolmentDate { get; set; }

        [Column("RaceNumber")]
        public int RaceNumber { get; set; }
    }
}
