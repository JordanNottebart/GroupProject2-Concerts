using CENV_JMH.DO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV.UI.Web.Models
{
    [Table("Showing_X_Hall")]
    public class AdminShowingInstance
    {
        [Key]
        [Column("ReGex_ID")]
        public int Id { get; set; }

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
