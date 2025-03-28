using ReservationAPI.Domain.AggregatteModel.AggregateReservation;
using ReservationAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private static readonly List<Reservation> _reservations = new List<Reservation>();

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await Task.FromResult(_reservations);
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await Task.FromResult(_reservations.FirstOrDefault(r => r.Id == id));
        }

        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            reservation.Id = _reservations.Count + 1;
            _reservations.Add(reservation);
            return await Task.FromResult(reservation);
        }

        public async Task<bool> HasReservationForDateTimeAsync(DateOnly date, string hour)
        {
            return await Task.FromResult(_reservations.Any(r =>
                r.Date == date &&
                r.Hour == hour));
        }

        public async Task<int> GetClientReservationsCountAsync(string clientName, DateOnly date)
        {
            return await Task.FromResult(_reservations.Count(r =>
                r.ClientName == clientName &&
                r.Date == date));
        }
    }
}