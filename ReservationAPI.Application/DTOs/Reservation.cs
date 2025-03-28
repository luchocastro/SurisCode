using ReservationAPI.Domain.Domain.Common;

namespace ReservationAPI.Domain.AggregatteModel.AggregateReservation
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ServiceId { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
    }
}