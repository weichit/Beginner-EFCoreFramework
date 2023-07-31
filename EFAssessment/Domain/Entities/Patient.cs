using System.ComponentModel.DataAnnotations;
namespace EFAssessment.Domain.Entities;

public class Patient
{
    private List<DomainEvent> _domainEvents = new List<DomainEvent>();
    public string PatientName { get; private set; }
    public Guid Id { get; private set; }
    public Guid SlotId { get; private set;}
    public Guid PatientId { get; private set; }
    public DateTime ReversedAt { get; private set; }

    // build constructor
    private Patient(string patientName, Guid slotId, Guid patientId, Guid id, DateTime reversedAt)
    {
        PatientName = patientName;
        SlotId = slotId;
        PatientId = patientId;
        Id = id;
        ReversedAt = reversedAt;
    }

    public IReadOnlyCollection<DomainEvent> GetOccuredEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public static Patient CreateNew(string patientName, Guid slotId, Guid patientId)
    {
        //when create new patient booking
        var patient = new Patient(patientName, slotId, patientId, Guid.NewGuid(), DateTime.UtcNow);
        patient._domainEvents.Add(new PatientCreated(patientName, patientId));
        return new Patient(patientName, slotId, patientId, Guid.NewGuid(), DateTime.UtcNow);
        
    }

    public interface DomainEvent
    {
    }

    public record PatientCreated(string patientName, Guid pateintId) : DomainEvent;
}