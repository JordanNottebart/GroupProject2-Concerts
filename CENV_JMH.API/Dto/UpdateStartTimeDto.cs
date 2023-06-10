using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.API.Dto
{
    public class UpdateStartTimeDto
    {
        [Required(ErrorMessage = "Please provide maximum number of places.")]
        public DateTime StartTime { get; set; }
    }
}
