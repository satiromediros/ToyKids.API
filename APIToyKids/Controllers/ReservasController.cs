using APIToyKids.Context;
using APIToyKids.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIToyKids.Controllers
{
    [Route("api/reservas")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<ResponseBase<IEnumerable<Reserva>>> Get()
        {
            var reservas = _context.Reservas.AsNoTracking().ToList();

            if (reservas is null)
            {
                var errorResponse = new ResponseBase<IEnumerable<Reserva>>(null, "Reservas não encontradas...", false);
                return NotFound(errorResponse);
            }

            var response = new ResponseBase<IEnumerable<Reserva>>(reservas, "", true);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ResponseBase<Reserva>> GetUser(int id)
        {
            var reserva = _context.Reservas.AsNoTracking().FirstOrDefault(r => r.ReservaId == id);

            if (reserva is null)
            {
                var errorResponse = new ResponseBase<Reserva>(null, "Reserva não encontrada...", false);
                return NotFound(errorResponse);
            }

            var response = new ResponseBase<Reserva>(reserva, "", true);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ResponseBase<int>> Add(Reserva reserva) 
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            var reservaId = reserva.ReservaId;

            var response = new ResponseBase<int>(reservaId, "Reserva cadastrada com sucesso.", true);
            return Ok(response);
        }

        [HttpGet("get-date")]
        public ActionResult<ResponseBase<IEnumerable<Reserva>>> GetReservas([FromQuery] DateTime data)
        {
            var reservas = _context.Reservas
                .Where(reserva => reserva.DataReserva.Date == data.Date)
                .ToList();

            if (reservas is null)
            {
                var errorResponse = new ResponseBase<IEnumerable<Reserva>>(null, "Nenhuma reserva foi encontrada...", false);
                return NotFound(errorResponse);
            }

            var response = new ResponseBase<IEnumerable<Reserva>>(reservas, "", true);
            return Ok(reservas);
        }
    }
}
