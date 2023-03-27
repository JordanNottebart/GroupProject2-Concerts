using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV.UI.Web.Models
{
    [Table("Hall_Table")]
    public class AdminHall
    {
        [Key]
        [Column("Hall_ID")]
        public int Id { get; set; }

        [Column("Max_Number_Places")]
        public int MaxNumberOfPlaces { get; set; }

        [Column("Name_Hall")]
        public string Name { get; set; }
    }
}
