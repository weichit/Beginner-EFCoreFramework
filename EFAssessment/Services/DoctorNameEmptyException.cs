using System.Runtime.Serialization;

namespace EFAssessment.Services
{
    [Serializable]
    internal class DoctorNameEmptyException : Exception
    {
        public DoctorNameEmptyException() : base(" DoctorName should not be empty !!! ")
        {
        }
    }
}