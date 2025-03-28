using ReservationAPI.Domain.AggregatteModel.AggregateReservation;
using ReservationAPI.Domain.Interfaces;
using System.Globalization;
using System.Threading.Tasks;

namespace ReservationAPI.Application.UseCases
{
    public class CreateReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IServiceRepository _serviceRepository;

        public CreateReservationUseCase(IReservationRepository reservationRepository, IServiceRepository serviceRepository)
        {
            _reservationRepository = reservationRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<Reservation> ExecuteAsync(ReservationDTO reservationDTO)
        {
            DateOnly date = new DateOnly(1, 1, 1);
            var ok = DateOnly.TryParseExact(reservationDTO.Date, Const.DateFormat, out date);
            if(!ok)
            {
                throw new InvalidCastException(Const.DateWithouFormat);
            }
            if (( DateOnly.FromDateTime( DateTime.Now)>= date) | (DateOnly.FromDateTime(DateTime.Now)==date &
                (int.Parse(DateTime.Now.ToString("Hmm")) > int.Parse(reservationDTO.Hour.Replace(Const.TimeSeparator, ""))))) 
            {
                throw new InvalidOperationException(Const.DateBeforeNow);
            }
            var reservation = new Reservation { ClientName = reservationDTO.ClientName, Date = date, Hour = reservationDTO.Hour, Id = reservationDTO.Id, ServiceId = reservationDTO.ServiceId };
            // Validar que no hay reserva para esa fecha y hora
            var hasReservation = await _reservationRepository.HasReservationForDateTimeAsync(reservation.Date, reservation.Hour);
            if (hasReservation)
            {
                throw new InvalidOperationException(Const.DateDisable);
            }

            // Validar que el cliente no tiene más de 2 reservas en el mismo día
            var clientReservationsCount = await _reservationRepository.GetClientReservationsCountAsync(reservation.ClientName, reservation.Date);
            if (clientReservationsCount >= 2)
            {
                throw new InvalidOperationException(Const.MoreOneVisit);
            }

            return await _reservationRepository.CreateAsync(reservation);
        }
    }
}