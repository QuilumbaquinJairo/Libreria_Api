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
        [HttpGet]
        public IActionResult Get()
        {
            var listaPrestamos = _context.Prestamos.ToList();
            var listaResultados = new List<Prestamo>();
            var prestamo = new Prestamo();
            foreach(var data in listaPrestamos)
            {
                prestamo.fechaSalida = data.fechaSalida;
                prestamo.fechaRegreso = data.fechaRegreso;
                prestamo.statusPrestamo = data.statusPrestamo;
                prestamo.IdPersona = data.IdPersona;
                prestamo.IdMaterialBibliografico = data.IdMaterialBibliografico;
                listaResultados.Add(prestamo);
            }
            return Ok(new { Status = "Success", Message = "Lista de libros obtenida", Libro = listaResultados });
        }

        [HttpPost]
        public IActionResult crearPrestamo(int idPersona,int idMaterial)
        {
            
            var listaLibros = _context.MaterialBibliograficos.ToList();
            var listaUsuarios = _context.Persona.ToList();
            var _validaciones = new CrearPrestamoValidacion();
            

            var validacion1 = _validaciones.validarLibro(listaLibros, idMaterial);
            var validacion2 = _validaciones.validarPersona(listaUsuarios, idPersona);

            try
            {
                if (ModelState.IsValid)
                {
                    if(validacion1 && validacion2) 
                    {
                        var nuevoPrestamo = new Prestamo
                        {
                            IdPersona = idPersona,
                            IdMaterialBibliografico = idMaterial,
                            
                        };
                        
                        listaLibros.Find(x => x.IdMaterialBibliografico == idMaterial).status = false;
                        _context.SaveChanges();
                        return Ok(new { Status = "Success", Libro = nuevoPrestamo });
                    }
                    else
                    {
                        Console.WriteLine("El usuario o el libro no son validos");
                        return BadRequest(new { Status = "Failed"});
                    }
                    

                    //_context.PrestamosAdd(nuevoPrestamo);
                    
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
