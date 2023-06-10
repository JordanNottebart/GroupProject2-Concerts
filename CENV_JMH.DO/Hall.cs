using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace CENV_JMH.DO
{
    #region Hall
    /// <summary>
    /// "Hall" represents a table in a database, with properties corresponding to columns in the
    ///  table.
    /// </summary> 
    #endregion

    [Table("Hall_Table")]
    public class Hall
    {
        [Key]
        [Column("Hall_ID")]
        public int HallID { get; set; }
        [Column("Name_Hall")]
        public string Name { get; set; }

        [Column("Max_Number_Places")]
        public int MaxNumberOfPlaces { get; set; }
    }
}