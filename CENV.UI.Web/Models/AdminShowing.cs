using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV.UI.Web.Models
{
    [Table("Showing")]
    public class AdminShowing
    {
        [Key]
        [Column("Showing_ID")]
        public int Id { get; set; }

        [Column("Name_Showing")]
        public string Name { get; set; }

        [Column("Ticket_Price")]
        public float TicketPrice { get; set; }
    }
}
