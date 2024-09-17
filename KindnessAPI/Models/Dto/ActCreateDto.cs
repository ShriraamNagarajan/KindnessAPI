using System.ComponentModel.DataAnnotations;

namespace KindnessAPI.Models.Dto
{
    public class ActCreateDto
    {

        [Required]
        public string Action { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public string TimeRequired { get; set; }

        [Required]
        public string LocationType { get; set; }

        [Required]
        public string ImpactType { get; set; }


    }
}
