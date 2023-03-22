﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENV_JMH.DO
{
    [Table("Showing_X_Hall")]

    public class ShowingDetail
    {
        [Key]
        [Column("ReGex_ID")]
        public int ID { get; set; }


        [ForeignKey(nameof(Showing))]
        [Column("Showing_ID")]
        public int ShowingID { get; set; }
        public Showing Showing { get; set; }

        [ForeignKey(nameof(Hall))]
        [Column("Hall_ID")]
        public int HallID { get; set; }
        public Hall Hall { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("Number_of_Seats_Sold")]
        public int SeatsSold { get; set; }

    }
}
