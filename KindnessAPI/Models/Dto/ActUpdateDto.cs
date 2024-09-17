using System.ComponentModel.DataAnnotations;

namespace KindnessAPI.Models.Dto
{
    public class ActUpdateDto
    {
        [Required]
        public int Id { get; set; }

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
