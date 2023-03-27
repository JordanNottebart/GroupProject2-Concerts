﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    [Table("Showing")]
    public class Showing
    {
        [Key]
        [Column("Showing_ID")]
        public int ShowingID { get; set; }

        [Column("Name_Showing")]
        public string Name { get; set; }

        [Column("Ticket_Price")]
        public float TicketPrice { get; set; }
    }
}
