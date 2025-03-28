using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Application.UseCases;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly GetServicesUseCase _getServicesUseCase;


        public ServiceController(GetServicesUseCase getServicesUseCase)
        {
            _getServicesUseCase = getServicesUseCase;
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            try
            {
                var services = await _getServicesUseCase.ExecuteAsync();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los servicios", error = ex.Message });
            }
        }
    }
}
