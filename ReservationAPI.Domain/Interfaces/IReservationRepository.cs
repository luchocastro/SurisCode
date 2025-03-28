using ReservationAPI.Domain.AggregatteModel.AggregateReservation;
using ReservationAPI.Domain.Common;
using ReservationAPI.Domain.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationAPI.Domain.Interfaces
{
    public interface IReservationRepository 
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<bool> HasReservationForDateTimeAsync(DateOnly date, string hour);
        Task<int> GetClientReservationsCountAsync(string clientName, DateOnly date);
    }
}