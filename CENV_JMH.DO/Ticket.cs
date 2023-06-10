using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENV_JMH.DO
{
    #region Ticket
    /// <summary>
    /// This class represents a relationshop between a user and a showing instance.
    /// </summary>
    #endregion

    public class Ticket
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public IdentityUser? User { get; set; }
        public ShowingInstance showingInstance { get; set; }
        public int showingInstanceId { get; set; }
    }
}
