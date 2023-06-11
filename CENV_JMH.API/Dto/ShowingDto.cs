using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.API.Dto
{
    public class ShowingDto
    {
        [Required(ErrorMessage = "Please provide a show name")]
        public string Name { get; set; }
        public double TicketPrice { get; set; }
        public string? Picture_URL { get; set; }
    }
}
