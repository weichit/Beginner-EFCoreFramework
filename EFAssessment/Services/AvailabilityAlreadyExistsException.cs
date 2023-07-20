using System.Runtime.Serialization;

namespace EFAssessment.Services
{
    [Serializable]
    public class AvailabilityAlreadyExistsException : Exception
    {
        public AvailabilityAlreadyExistsException(Guid Id) : base($" Availability with Id {Id} is already existed !!! ")
        {

        }
    }
}