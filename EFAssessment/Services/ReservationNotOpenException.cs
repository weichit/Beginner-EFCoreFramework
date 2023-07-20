using System.Runtime.Serialization;

namespace EFAssessment.Services
{
    [Serializable]
    public class ReservationNotOpenException : Exception
    {
        
        public ReservationNotOpenException(Guid soltId) : base($" Reservation for this {soltId} has closed !!! ")
        {

        }

    }
}