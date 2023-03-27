using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    
    [Table("Showing")]
    public class Showing
    {
        [Column("Name_Showing")]
        public string Name { get; set; }
        [Column("Ticket_Price")]
        public double TicketPrice { get; set; }

        [Key]
        [Column("Showing_ID")]
        public int ShowingID { get; set; }

        [Column("Picture_URL")]
        public string? Picture_URL { get; set;}
        
    }
}
