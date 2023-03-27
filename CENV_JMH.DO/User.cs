using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("User_ID")]
        public int Id { get; set; }

        [Column("User_Name")]
        public string Name { get; set; }

        [Column("User_Password")]
        public string Password { get; set; }

    }
}