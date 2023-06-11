using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.API.Dto
{
    public class AuthenticationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
