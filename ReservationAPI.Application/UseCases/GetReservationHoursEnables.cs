using ReservationAPI.Domain.AggregatteModel.AggregateReservation;

using ReservationAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationAPI.Application.UseCases
{
    public class GetReservationHoursEnables
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationHoursEnables(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<string>> ExecuteAsync(string sdate)
        {

            DateOnly date = new DateOnly(1, 1, 1);
            var ok = DateOnly.TryParseExact(sdate, Const.DateFormat, out date);
            if (!ok)
            {
                throw new InvalidCastException(Const.DateWithouFormat);
            }
            //deberìa vernir de la DB
            var ap = 8;
            var cs = 12;
            var aps = 16;
            var c = 20;
            var hours =  _reservationRepository.GetAllAsync().Result.Where(f=>f.Date==date).Select(x=> int.Parse( x.Hour??"0".Replace(":","") ));
            var TotalHours = Enumerable.Range(ap, cs);
            TotalHours.ToList().AddRange(Enumerable.Range(aps, c));
            
            return  TotalHours.Where(h => hours.ToList().IndexOf(h) < 0).Select(x => x.ToString().PadLeft(2, '0') + ":00");


        }
    }
}