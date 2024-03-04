using LibreriaORM.Data;
using LibreriaORM.Modelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public LibrosController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public IActionResult GetLibros()
        {
            try
            {
                var listaLibros = _context.Libros.ToList();
                var listaResultado = new List<LibroDTO>();

                foreach (var libro in listaLibros)
                {
                    var libroDTO = new LibroDTO
                    {
                        Autor = libro.autor,
                        Titulo = libro.titulo,
                        Anio = libro.anio,
                        Status = libro.status,
                        EditorialLibro = libro.editorialLibro
                    };

                    listaResultado.Add(libroDTO);
                }

                return Ok(listaResultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }


        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public IActionResult GetLibro(int id)
        {
            try
            {
                var libro = _context.Libros.FirstOrDefault(l => l.IdMaterialBibliografico == id);

                if (libro != null)
                {
                    var libroDTO = new LibroDTO
                    {
                        Autor = libro.autor,
                        Titulo = libro.titulo,
                        Anio = libro.anio,
                        Status = libro.status,
                        EditorialLibro = libro.editorialLibro
                    };

                    return Ok(new { Status = "Success", Libro = libroDTO });
                }
                else
                {
                    return NotFound("Libro no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] LibroDTO libroDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (libroDTO.Anio > DateTime.Now.Year)
                    {
                        // Mensaje de error si el año es posterior al actual
                        return BadRequest("El año no puede ser posterior al actual");
                    }

                    var nuevoLibro = new Libro
                    {
                        autor = libroDTO.Autor,
                        titulo = libroDTO.Titulo,
                        anio = libroDTO.Anio,
                        status = libroDTO.Status,
                        editorialLibro = libroDTO.EditorialLibro
                    };

                    _context.Libros.Add(nuevoLibro);
                    _context.SaveChanges();


                    return Ok("Libro creado exitosamente");
                }
                else
                {
                    // Extraer el primer mensaje de error
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


        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LibroDTO libroDTO)
        {
            try
            {
                var libro = _context.Libros.FirstOrDefault(l => l.IdMaterialBibliografico == id);

                if (libro != null)
                {
                    libro.autor = libroDTO.Autor;

                    libro.titulo = libroDTO.Titulo;
                    libro.anio = libroDTO.Anio;
                    libro.status = libroDTO.Status;
                    libro.editorialLibro = libroDTO.EditorialLibro;

                    _context.SaveChanges();

                    return Ok("Libro actualizado exitosamente");
                }
                else
                {
                    return NotFound("Libro no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var libro = _context.Libros.FirstOrDefault(l => l.IdMaterialBibliografico == id);

                if (libro != null)
                {
                    _context.Libros.Remove(libro);
                    _context.SaveChanges();

                    return Ok("Libro eliminado exitosamente");
                }
                else
                {
                    return NotFound("Libro no encontrado");
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
