using LibreriaORM.Data;
using LibreriaORM.Modelo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private LibreriaContext _context;
        public UsuariosController(LibreriaContext context)
        {
            _context = context;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public Task<List<Usuario>> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                var listaUsuarios = _context.Usuarios.ToList();
                var query =
                from usuario in listaUsuarios
                select new
                {
                    usuarioNombre = usuario.nombre,
                    usuarioApellido = usuario.apellido,
                    usuarioTelefono = usuario.telefono,
                    usuarioSancion = usuario.sancion,
                    usuarioCorreo = usuario.correo,
                    usuarioFacultad = usuario.Facultad
                };
                Usuario dtoUsuario = new();
                foreach (var dato in query)
                {
                    dtoUsuario.nombre = dato.usuarioNombre;
                    dtoUsuario.apellido = dato.usuarioApellido;
                    dtoUsuario.correo = dato.usuarioCorreo;
                    dtoUsuario.telefono = dato.usuarioTelefono;
                    dtoUsuario.sancion = dato.usuarioSancion;
                    dtoUsuario.Facultad = dato.usuarioFacultad;
                    usuarios.Add(dtoUsuario);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception: {ex.Message}");
            }

            
           
            

            return Task.Run(()=>usuarios);
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Crear un nuevo objeto Usuario y asignarle los valores del DTO
                    var nuevoUsuario = new Usuario
                    {
                        nombre = userDTO.Nombre,
                        apellido = userDTO.Apellido,
                        correo = userDTO.Correo,
                        telefono = userDTO.Telefono,
                        sancion = userDTO.Sancion,
                        Facultad = userDTO.Facultad
                    };

                    // Agregar el nuevo usuario al contexto y guardar los cambios
                    _context.Usuarios.Add(nuevoUsuario);
                    _context.SaveChanges();

                    // Devolver una respuesta de éxito con el nuevo usuario creado
                    return CreatedAtAction(nameof(GetUsuarios), nuevoUsuario);
                }
                else
                {
                    // Si el modelo no es válido, devolver un error de solicitud incorrecta
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Log o manejar la excepción
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
