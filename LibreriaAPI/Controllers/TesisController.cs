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
    public class TesisController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public TesisController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: api/<TesisController>
        [HttpGet]
        public IActionResult GetTesis()
        {
            try
            {
                var listaTesis = _context.Tesis.ToList();
                var listaResultado = new List<TesisDTO>();

                foreach (var tesis in listaTesis)
                {
                    var tesisDTO = new TesisDTO
                    {
                        Autor = tesis.autor,
                        Titulo = tesis.titulo,
                        Anio = tesis.anio,
                        Status = tesis.status
                    };

                    listaResultado.Add(tesisDTO);
                }

                return Ok(new { Status = "Success", Tesis = listaResultado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }


        // GET api/<TesisController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var tesis = _context.Tesis.FirstOrDefault(t => t.IdMaterialBibliografico == id);

                if (tesis != null)
                {
                    var tesisDTO = new TesisDTO
                    {
                        Autor = tesis.autor,
                        Titulo = tesis.titulo,
                        Anio = tesis.anio,
                        Status = tesis.status
                    };

                    return Ok(new { Status = "Success", Tesis = tesisDTO });
                }
                else
                {
                    return NotFound("Tesis no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        // POST api/<TesisController>
        [HttpPost]
        public IActionResult Post([FromBody] TesisDTO tesisDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (tesisDTO.Anio > DateTime.Now.Year)
                    {
                        // Mensaje de error si el año es posterior al actual
                        return BadRequest("El año no puede ser posterior al actual" );
                    }

                    var nuevaTesis = new Tesis
                    {
                        autor = tesisDTO.Autor,
                        titulo = tesisDTO.Titulo,
                        anio = tesisDTO.Anio,
                        status = tesisDTO.Status
                    };

                    _context.Tesis.Add(nuevaTesis);
                    _context.SaveChanges();

                    return CreatedAtAction(nameof(GetTesis), "Tesis creada exitosamente");
                }
                else
                {
                    // Extraer el mensaje de error personalizado
                    var errorMessage = ModelState["Anio"].Errors.FirstOrDefault()?.ErrorMessage;
                    return BadRequest(new { Message = errorMessage });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor", ExceptionMessage = ex.InnerException?.Message });
            }
        }

        // PUT api/<TesisController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TesisDTO tesisDTO)
        {
            try
            {
                var tesis = _context.Tesis.FirstOrDefault(t => t.IdMaterialBibliografico == id);

                if (tesis != null)
                {
                    tesis.autor = tesisDTO.Autor;
                    tesis.titulo = tesisDTO.Titulo;
                    tesis.anio = tesisDTO.Anio;
                    tesis.status = tesisDTO.Status;

                    _context.SaveChanges();

                    return Ok("Tesis actualizada exitosamente");
                }
                else
                {
                    return NotFound("Tesis no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        // DELETE api/<TesisController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var tesis = _context.Tesis.FirstOrDefault(t => t.IdMaterialBibliografico == id);

                if (tesis != null)
                {
                    _context.Tesis.Remove(tesis);
                    _context.SaveChanges();

                    return Ok("Tesis eliminada exitosamente");
                }
                else
                {
                    return NotFound("Tesis no encontrada");
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
