using ReservationAPI.Domain.AggregatteModel.AggregateService;
using ReservationAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationAPI.Application.UseCases
{
    public class GetServicesUseCase
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServicesUseCase(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> ExecuteAsync()
        {
            return await _serviceRepository.GetAllAsync();
        }
    }
}