using APIToyKids.Context;
using APIToyKids.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIToyKids.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<ResponseBase<IEnumerable<Usuario>>> Get()
        {
            var usuarios = _context.Usuarios.Include(u => u.Reservas).AsNoTracking().ToList();

            if (usuarios is null)
            {
                var errorResponse = new ResponseBase<IEnumerable<Usuario>>(null, "Usuários não encontrados...", false);
                return NotFound(errorResponse);
            }

            var response = new ResponseBase<IEnumerable<Usuario>>(usuarios, "", true);                

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ResponseBase<Usuario>> GetUser(int id) 
        {
            var usuario = _context.Usuarios.Include(u => u.Reservas).AsNoTracking().FirstOrDefault(u => u.UsuarioId == id);

            if (usuario is null)
            {
                var errorResponse = new ResponseBase<Usuario>(null, "Usuário não encontrado...", false);
                return NotFound(errorResponse);
            }

            var response = new ResponseBase<Usuario>(usuario, "", true);
            return Ok(response);
        }

        [HttpGet("login")]
        public ActionResult<ResponseBase<Usuario>> Authenticate([FromQuery] string CPF, string senha)
        {
            var usuario = _context.Usuarios.Include(u => u.Reservas).AsNoTracking().FirstOrDefault(u => u.CPF.Equals(CPF) && u.Senha.Equals(senha));

            if (usuario is null)
            {
                var errorResponse = new ResponseBase<Usuario>(null, "Usuário não cadastrado...", false);
                return NotFound(errorResponse);
            }

            var response = new ResponseBase<Usuario>(usuario, "", true);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ResponseBase<int>> Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            var usuarioId = usuario.UsuarioId;

            var response = new ResponseBase<int>(usuarioId, "Usuário cadastrado com sucesso.", true);
            return Ok(response);
        }
    }
}
