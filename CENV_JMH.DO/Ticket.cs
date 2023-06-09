using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.DO
{
    public class Ticket
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public IdentityUser? User { get; set; }
        //public ShowingInstance ShowingInstance { get; set; }

        public int showingInstanceId { get; set; }
    }
}
