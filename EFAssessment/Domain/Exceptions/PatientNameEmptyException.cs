using System.Runtime.Serialization;

namespace EFAssessment.Domain.Exceptions
{
    [Serializable]
    public class PatientNameEmptyException : Exception
    {
        public PatientNameEmptyException() : base(" PatientName should not be empty !!! ")
        {
        }
    }
}