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
        CrearPrestamoValidacion _validaciones = new CrearPrestamoValidacion();
        public PrestamoController(LibreriaContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listaPrestamos = _context.Prestamos.ToList();
            var listaResultados = new List<PrestamoDTO>();
            var prestamo = new PrestamoDTO();
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

        [HttpGet("{idPersona}")]
        public IActionResult Get(int idPersona)
        {
            var listaPrestamos = _context.Prestamos.ToList();
            var listaPersonas = _context.Persona.ToList();
            var query =
                from pres in listaPrestamos
                join persona in listaPersonas on pres.IdPersona equals persona.IdPersona
                where persona.IdPersona == idPersona
                select pres;
            
            var listaResultados = new List<PrestamoDTO>();
            var prestamo = new PrestamoDTO();
            foreach (var data in listaPrestamos)
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
                        _context.Prestamos.Add(nuevoPrestamo);
                        _context.SaveChanges();
                        return Ok(new { Status = "Success", Prestamo = nuevoPrestamo });
                    }
                    else
                    {
                        Console.WriteLine("El usuario o el libro no son validos");
                        return BadRequest(new { Status = "Failed"});
                    }
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
        [HttpPut]
        public IActionResult DevolverPrestamo(int idPersona)
        {
            var listaPrestamos = _context.Prestamos.ToList();
            var listaMaterial = _context.MaterialBibliograficos.ToList();
            var listaPersonas = _context.Persona.ToList();
            var validacionPrestamo = _validaciones.validarHistorial(idPersona, listaPrestamos);

            try
            {
                if (ModelState.IsValid)
                {
                    if (validacionPrestamo)
                    {

                        listaPrestamos.Find(x => x.IdPersona == idPersona).statusPrestamo = false;
                        var query =
                            from material in listaMaterial
                            join prestamo in listaPrestamos on material.IdMaterialBibliografico equals prestamo.IdMaterialBibliografico
                            where prestamo.IdPersona == idPersona
                            select material;

                        listaMaterial.Find(x => x.IdMaterialBibliografico == query.First().IdMaterialBibliografico).status = true;
                        var fecha = listaPrestamos.Find(x => x.IdPersona == idPersona).fechaRegreso;
                        var fechaValidar = DateTime.Parse(fecha);
                        if (fechaValidar<DateTime.Now)
                        {
                            listaPersonas.Find(x => x.IdPersona == idPersona).sancion = true;   
                        }

                        _context.SaveChanges();
                        return Ok("Prestamo Actualizado");
                    }
                    else
                    {
                        Console.WriteLine("El usuario o el libro no son validos");
                        return BadRequest(new { Status = "Failed" });
                    }
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
