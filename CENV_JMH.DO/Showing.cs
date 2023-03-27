using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    
    [Table("Showing")]
    public class Showing
    {
        [Key]
        [Column("Name_Showing")]
        public string Name { get; set; }
        [Column("Ticket_Price")]
        public float TicketPrice { get; set; }

        [Column("Showing_ID")]
        public int ShowingID { get; set; }

        [Column("Picture_URL")]
        public string Picture_URL { get; set;}
        
    }
}
