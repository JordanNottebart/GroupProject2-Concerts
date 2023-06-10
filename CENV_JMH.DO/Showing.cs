using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    #region Showing
    /// <summary>
    /// "Showing" represents a table in a database, with properties corresponding to columns in the
    ///  table.
    /// </summary> 
    #endregion

    [Table("Showing")]
    public class Showing
    {
        [Key]
        [Column("Showing_ID")]
        public int ShowingID { get; set; }
        [Column("Name_Showing")]
        public string Name { get; set; }

        [Column("Ticket_Price")]
        public double TicketPrice { get; set; }
        [Column("Picture_URL")]
        public string? Picture_URL { get; set; }
    }
}
