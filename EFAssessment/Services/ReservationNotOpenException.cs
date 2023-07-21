using System.Runtime.Serialization;

namespace EFAssessment.Services
{
    [Serializable]
    public class ReservationNotOpenException : Exception
    {

        public ReservationNotOpenException(Guid slotId) : base($" The slot {slotId} is not available for booking !!! ")
        {
        }
    }
}