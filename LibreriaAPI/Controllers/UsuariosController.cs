using LibreriaORM.Data;
using LibreriaORM.Modelo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult GetUsuarios()
        {
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
                return Ok(query);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verificar unicidad del correo electrónico
                    if (_context.Usuarios.Any(u => u.correo == userDTO.Correo))
                    {
                        ModelState.AddModelError("Correo", "El correo electrónico ya está en uso");
                        return BadRequest(ModelState);
                    }

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
        public IActionResult Put(int id, [FromBody] UsuarioDTO userDTO)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                usuario.nombre = userDTO.Nombre;
                usuario.apellido = userDTO.Apellido;
                usuario.correo = userDTO.Correo;
                usuario.telefono = userDTO.Telefono;
                usuario.sancion = userDTO.Sancion;
                usuario.Facultad = userDTO.Facultad;

                _context.SaveChanges();

                return Ok("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
