using EFAssessment.Services;
using System.ComponentModel.DataAnnotations;

namespace EFAssessment.Controllers.Dtos;


public class CreatePatientRequest
{
  
    public string PatientName { get; set; }
    public Guid Id { get; set; }
    public Guid SlotId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime ReversedAt { get; set; }

}


