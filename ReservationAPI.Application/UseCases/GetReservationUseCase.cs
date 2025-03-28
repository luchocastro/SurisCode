using ReservationAPI.Domain.AggregatteModel.AggregateReservation;

using ReservationAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationAPI.Application.UseCases
{
    public class GetReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> ExecuteAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }
    }
}