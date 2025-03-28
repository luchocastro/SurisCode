using HexColorsProvider.Domain.Common;
using ReservationAPI.Domain.Domain.Common;

namespace ReservationAPI.Domain.AggregatteModel.AggregateReservation
{
    public class Reservation :Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ServiceId { get; set; }
        public DateOnly Date { get; set; }
        public string Hour { get; set; }
    }
}