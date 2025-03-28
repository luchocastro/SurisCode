using ReservationAPI.Domain.AggregatteModel.AggregateService;
using ReservationAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private static readonly List<Service> _services = new List<Service>
        {
            new Service { Id = "1" , Name = "Corte de cabello" },
            new Service { Id = "2", Name = "Tinte" },
            new Service { Id = "3" , Name = "Manicura" },
            new Service { Id = "4" , Name = "Pedicura" },
            new Service { Id = "5" , Name = "Tratamiento facial" }
        };

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await Task.FromResult(_services);
        }

        public async Task<Service> GetByIdAsync(string id)
        {
            return await Task.FromResult(_services.FirstOrDefault(s => s.Id == id));
        }
    }
}