using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.API.Dto
{
    public class HallDto
    {
        [Required(ErrorMessage = "Please provide a hall name")]
        public string Name { get; set; }
        public int MaxNumberOfPlaces { get; set; }
    }
}
