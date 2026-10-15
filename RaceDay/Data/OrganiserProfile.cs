
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.Data
{
    [Table("Organiser Profile", Schema = "dbo")]
    public class OrganiserProfile
    {
        [Key]
        [Column("Organiser Profile ID")]
        public int OrganiserProfileID { get; set; }

        public int UserID { get; set; }

        [Column("Organisation Name")]
        public string OrganisationName { get; set; } = string.Empty;

        [Column("Contact Email")]
        public string ContactEmail { get; set; } = string.Empty;

        [Column("Contact Phone")]
        public string ContactPhone { get; set; } = string.Empty;
    }
}
