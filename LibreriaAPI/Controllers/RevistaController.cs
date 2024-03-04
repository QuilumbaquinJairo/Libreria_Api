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
    public class RevistaController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public RevistaController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: api/<RevistaController>
        [HttpGet]
        public IActionResult GetRevistas()
        {
            try
            {
                var listaRevistas = _context.Revista.ToList();
                List<RevistaDTO> listaResultado = new List<RevistaDTO>();

                foreach (var revista in listaRevistas)
                {
                    RevistaDTO revistaDTO = new RevistaDTO
                    {
                        Autor = revista.autor,
                        Titulo = revista.titulo,
                        Anio = revista.anio,
                        Status = revista.status,
                        EditorialRevista = revista.EditorialRevista
                    };

                    listaResultado.Add(revistaDTO);
                }

                return Ok(listaResultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        // GET api/<RevistaController>/5
        [HttpGet("{id}")]
        public IActionResult GetRevista(int id)
        {
            try
            {
                var revista = _context.Revista.FirstOrDefault(r => r.IdMaterialBibliografico == id);

                if (revista != null)
                {
                    var revistaDTO = new RevistaDTO
                    {
                        Autor = revista.autor,
                        Titulo = revista.titulo,
                        Anio = revista.anio,
                        Status = revista.status,
                        EditorialRevista = revista.EditorialRevista
                    };

                    return Ok(revistaDTO);
                }
                else
                {
                    return NotFound("Revista no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // POST api/<RevistaController>
        [HttpPost]
        public IActionResult Post([FromBody] RevistaDTO revistaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (revistaDTO.Anio > DateTime.Now.Year)
                    {
                        // Mensaje de error si el año es posterior al actual
                        return BadRequest("El año no puede ser posterior al actual");
                    }

                    var nuevaRevista = new Revista
                    {
                        autor = revistaDTO.Autor,
                        titulo = revistaDTO.Titulo,
                        anio = revistaDTO.Anio,
                        status = revistaDTO.Status,
                        EditorialRevista = revistaDTO.EditorialRevista
                    };

                    _context.Revista.Add(nuevaRevista);
                    _context.SaveChanges();

                    return CreatedAtAction(nameof(GetRevistas), "Revista creada exitosamente");
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



        // PUT api/<RevistaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RevistaDTO revistaDTO)
        {
            try
            {
                var revista = _context.Revista.FirstOrDefault(r => r.IdMaterialBibliografico == id);

                if (revista != null)
                {
                    revista.autor = revistaDTO.Autor;
                    revista.titulo = revistaDTO.Titulo;
                    revista.anio = revistaDTO.Anio;
                    revista.status = revistaDTO.Status;
                    revista.EditorialRevista = revistaDTO.EditorialRevista;

                    _context.SaveChanges();

                    return Ok("Revista actualizada exitosamente");
                }
                else
                {
                    return NotFound("Revista no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        // DELETE api/<RevistaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var revista = _context.Revista.FirstOrDefault(r => r.IdMaterialBibliografico == id);

                if (revista != null)
                {
                    _context.Revista.Remove(revista);
                    _context.SaveChanges();

                    return Ok("Revista eliminada exitosamente");
                }
                else
                {
                    return NotFound("Revista no encontrada");
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
