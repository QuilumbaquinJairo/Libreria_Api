using LibreriaORM.Data;
using LibreriaORM.Modelo;
using LibreriaORM.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaAPI.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        public LibreriaContext _context;
        public PrestamoController(LibreriaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult crearPrestamo(PrestamoDTO prestamoDTO)
        {
            var fecha = new Fecha();
            var listaLibros = _context.MaterialBibliograficos.ToList();
            var listaUsuarios = _context.Persona.ToList();
            var _validaciones = new CrearPrestamoValidacion();
            

            var validacion1 = _validaciones.validarLibro(listaLibros, prestamoDTO);
            var validacion2 = _validaciones.validarPersona(listaUsuarios, prestamoDTO);

            try
            {
                if (ModelState.IsValid)
                {
                    if(validacion1 && validacion2) 
                    {
                        var nuevoPrestamo = new Prestamo
                        {
                            
                            fechaSalida = fecha.fechaSalida.ToString(),
                            fechaRegreso = fecha.fechaRegreso.ToString(),
                            IdPersona = prestamoDTO.IdPersona,
                            IdMaterialBibliografico = prestamoDTO.IdMaterialBibliografico,
                        };
                        return Ok(new { Status = "Success", Libro = nuevoPrestamo });
                    }
                    else
                    {
                        Console.WriteLine("El usuario o el libro no son validos");
                        return BadRequest(new { Status = "Failed", Libro = prestamoDTO });
                    }
                    

                    //_context.PrestamosAdd(nuevoPrestamo);
                    //_contextSaveChanges();
                }
                else
                {
                    return BadRequest(ModelState);
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
