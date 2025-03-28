using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Application.UseCases;
using ReservationAPI.Domain.AggregatteModel.AggregateReservation;
using System;
using System.Threading.Tasks;

namespace ReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        
        private readonly CreateReservationUseCase _createReservationUseCase;
        private readonly GetReservationUseCase _getReservationUseCase;
        private readonly GetReservationHoursEnables _getReservationHoursEnables;
        public ReservationController(
            GetReservationUseCase getReservationUseCase,
            CreateReservationUseCase createReservationUseCase,
            GetReservationHoursEnables getReservationHoursEnables)
        {
            _getReservationUseCase = getReservationUseCase;
            _createReservationUseCase = createReservationUseCase;
            _getReservationHoursEnables= getReservationHoursEnables;
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> GetReservation()
        {
            try
            {
                var reservations = await _getReservationUseCase.ExecuteAsync();
                 return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los reservas", error = ex.Message });
            }
        }
        [HttpGet("hours")]
        public async Task<IActionResult> GetHours( string date)
        {
            try
            {
                var hours = await _getReservationHoursEnables.ExecuteAsync(date);
                return Ok(hours);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los horarios", error = ex.Message });
            }
        }
        [HttpPost("CreateReservation")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDTO  reservation)
        {
            try
            {
                var createdReservation = await _createReservationUseCase.ExecuteAsync(reservation);
                return CreatedAtAction(nameof(CreateReservation), new { id = createdReservation.Id }, createdReservation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear la reserva", error = ex.Message });
            }
        }
    }
}