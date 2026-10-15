using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.Data
{
    [Table("Event", Schema = "dbo")]
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [StringLength(100)]
        public string EventName { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }

        [StringLength(150)]
        public string Location { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public int OrganiserID { get; set; }
    }
}