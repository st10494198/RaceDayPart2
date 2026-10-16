
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.Data
{
    [Table("Participant Profile", Schema = "dbo")]
    public class ParticipantProfile
    {
        [Key]
        [Column("Profile ID")]
        public int ProfileID { get; set; }

        public int UserID { get; set; }

        [Column("DateOf Birth")]
        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        [Column("EmergencyContact")]
        public string? EmergencyContact { get; set; }

        [Column("Emergency Phone")]
        public string? EmergencyPhone { get; set; }
    }
}
