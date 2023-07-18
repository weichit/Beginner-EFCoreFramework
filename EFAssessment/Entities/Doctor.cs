using System.ComponentModel.DataAnnotations;

namespace EFAssessment.Entities
{
    public class Doctor
    {
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid DoctorId { get; set; }
        public bool IsReversed { get; set; }
        public decimal Cost { get; set; }   
        public DateTime Time { get; set; }

    }
}
