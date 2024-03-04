using LibreriaORM.Data;
using LibreriaORM.Modelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public AdministradorController(LibreriaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAdministradores()
        {
            try
            {
                var administradores = _context.Administrador.ToList();
                var administradoresDTO = administradores.Select(administrador => new AdministradorDTO
                {
                    Nombre = administrador.nombre,
                    Apellido = administrador.apellido,
                    Correo = administrador.correo,
                    Telefono = administrador.telefono,
                    Sancion = administrador.sancion,
                    Contrasenia = administrador.contrasenia,
                    Privilegios = administrador.privilegios
                }).ToList();

                return Ok(administradoresDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetAdministrador(int id)
        {
            try
            {
                var administrador = _context.Administrador.FirstOrDefault(a => a.IdPersona == id);

                if (administrador != null)
                {
                    var administradorDTO = new AdministradorDTO
                    {
                        Nombre = administrador.nombre,
                        Apellido = administrador.apellido,
                        Correo = administrador.correo,
                        Telefono = administrador.telefono,
                        Sancion = administrador.sancion,
                        Contrasenia = administrador.contrasenia,
                        Privilegios = administrador.privilegios
                    };

                    return Ok(administradorDTO);
                }
                else
                {
                    return NotFound("Administrador no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public IActionResult PostAdministrador([FromBody] AdministradorDTO administradorDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!Regex.IsMatch(administradorDTO.Privilegios, @"^(read|create|update|delete)$"))
                    {
                        return BadRequest("Los privilegios deben ser 'read', 'create', 'update' o 'delete'.");
                    }

                    var nuevoAdministrador = new Administrador
                    {
                        nombre = administradorDTO.Nombre,
                        apellido = administradorDTO.Apellido,
                        correo = administradorDTO.Correo,
                        telefono = administradorDTO.Telefono,
                        sancion = administradorDTO.Sancion,
                        contrasenia = administradorDTO.Contrasenia,
                        privilegios = administradorDTO.Privilegios
                    };

                    _context.Administrador.Add(nuevoAdministrador);
                    _context.SaveChanges();

                    return Ok("Administrador creado exitosamente");
                }
                else
                {
                    var errorMessage = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage;
                    return BadRequest(errorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor", ExceptionMessage = ex.InnerException?.Message });
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutAdministrador(int id, [FromBody] AdministradorDTO administradorDTO)
        {
            try
            {
                var administrador = _context.Administrador.FirstOrDefault(a => a.IdPersona == id);

                if (administrador != null)
                {
                    administrador.nombre = administradorDTO.Nombre;
                    administrador.apellido = administradorDTO.Apellido;
                    administrador.correo = administradorDTO.Correo;
                    administrador.telefono = administradorDTO.Telefono;
                    administrador.sancion = administradorDTO.Sancion;
                    administrador.contrasenia = administradorDTO.Contrasenia;
                    administrador.privilegios = administradorDTO.Privilegios;

                    _context.SaveChanges();

                    return Ok("Administrador actualizado exitosamente");
                }
                else
                {
                    return NotFound("Administrador no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdministrador(int id)
        {
            try
            {
                var administrador = _context.Administrador.FirstOrDefault(a => a.IdPersona == id);

                if (administrador != null)
                {
                    _context.Administrador.Remove(administrador);
                    _context.SaveChanges();

                    return Ok("Administrador eliminado exitosamente");
                }
                else
                {
                    return NotFound("Administrador no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }
    }
}
