using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.API.Dto
{
    public class ShowingInstanceDto
    {
        [Required(ErrorMessage = "Please provide a ShowingID")]
        public int ShowingID { get; set; }

        [Required(ErrorMessage = "Please provide a HallID")]
        public int HallID { get; set; }

        [Required(ErrorMessage = "Please provide a Date")]
        public DateTime Date { get; set; }
    }
}
