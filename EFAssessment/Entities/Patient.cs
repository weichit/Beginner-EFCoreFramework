using System.ComponentModel.DataAnnotations;
namespace EFAssessment.Entities;

public class Patient
{
    [Required]
    public string PatientName { get; set; }
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid SlotId { get; set; }
    [Required]
    public Guid PatientId { get; set; }
    public DateTime ReversedAt { get; set; }
}