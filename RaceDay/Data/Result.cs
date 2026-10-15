
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.Data
{
    [Table("Result", Schema = "dbo")]
    public class Result
    {
        [Key]
        [Column("ResultID")]
        public int ResultID { get; set; }

        [Column("EnrolmentID")]
        public int EnrolmentID { get; set; }

        [Column("FinishTime")]
        public TimeSpan FinishTime { get; set; }

        [Column("Position")]
        public int Position { get; set; }

        [Column("Status")]
        public string Status { get; set; } = string.Empty;
    }
}
