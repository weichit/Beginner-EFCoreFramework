using System.ComponentModel.DataAnnotations;
namespace EFAssessment.Entities;

public class Patient
{
    public string PatientName { get; set; }
    public Guid Id { get; set; }
    public Guid SlotId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime ReversedAt { get; set; }
}