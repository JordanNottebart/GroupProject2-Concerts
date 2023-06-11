using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    #region ShowingInstance
    /// <summary>
    /// "ShowingInstance" represents a showing instance in a system, with properties corresponding
    /// to columns in the associated database table. It establishes relationships with the
    /// "Showing" and "Hall" classes through foreign key properties.
    /// </summary> 
    #endregion

    [Table("Showing_X_Hall")]
    public class ShowingInstance
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
        [DisplayName("Seats Sold")]
        public int SeatsSold { get; set; }
    }
}
