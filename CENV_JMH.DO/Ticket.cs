using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CENV_JMH.DO
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [Column("Ticket_ID")]
        public int ID { get; set; }

        [ForeignKey(nameof(Showing))]
        [Column("Ticket_Showing_ID")]
        public int ShowingID { get; set; }

        public Showing Showing { get; set; }

        [ForeignKey(nameof(Buyer))]
        [Column("Ticket_Buyer_ID")]
        public int BuyerID { get; set; }

        public User Buyer { get; set; }
    }
}
