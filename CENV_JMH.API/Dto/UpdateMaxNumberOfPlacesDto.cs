using System.ComponentModel.DataAnnotations;

namespace CENV_JMH.API.Dto
{
    public class UpdateMaxNumberOfPlacesDto
    {
        [Required(ErrorMessage = "Please provide maximum number of places.")]
        public int MaxNumberOfPlaces { get; set; }
    }
}
