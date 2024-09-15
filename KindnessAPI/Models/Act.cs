using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindnessAPI.Models
{
    public class Act
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Action { get; set; }

        [Required]
        [StringLength(50)]
        public string Difficulty { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeRequired { get;  set; }

        [Required]
        [StringLength(50)]  
        public string LocationType { get; set; }

        [Required]
        [StringLength(50)]
        public string ImpactType { get; set; }

        [Required]
        [StringLength(50)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
