using System.Runtime.Serialization;

namespace EFAssessment.Domain.Exceptions
{
    [Serializable]
    public class AvailabilityAlreadyExistsException : Exception
    {
        public AvailabilityAlreadyExistsException(Guid Id) : base($" Availability with Id {Id} is already existed !!! ")
        {

        }
    }
}