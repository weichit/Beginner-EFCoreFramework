namespace EFAssessment.Entities
{
    public class Doctor
    {
        public string DoctorName { get; set; }
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public bool IsReversed { get; set; }
        public decimal Cost { get; set; }   
        public DateTime Time { get; set; }

    }
}
