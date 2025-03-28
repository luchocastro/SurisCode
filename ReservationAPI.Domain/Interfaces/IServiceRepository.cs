using ReservationAPI.Domain.AggregatteModel.AggregateService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationAPI.Domain.Interfaces
{
    public  interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
    }
}