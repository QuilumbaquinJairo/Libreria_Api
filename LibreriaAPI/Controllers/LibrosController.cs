using LibreriaORM.Data;
using LibreriaORM.Modelo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private LibreriaContext _context;
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
                List<LibroDTO> listaResultado = new List<LibroDTO>();

                foreach (var dato in listaLibros)
                {
                    LibroDTO libroDTO = new LibroDTO();  // Crear un nuevo objeto en cada iteración

                    libroDTO.Autor = dato.autor;
                    libroDTO.EditorialLibro = dato.editorialLibro;
                    libroDTO.Titulo = dato.titulo;
                    libroDTO.Anio = dato.anio;
                    libroDTO.Status = dato.status;

                    listaResultado.Add(libroDTO);
                }

                // Devolver una respuesta de éxito con la lista de libros y el código 200 OK
                return Ok(new { Status = "Success", Libros = listaResultado });
            }
            catch (Exception ex)
            {
                // Log o manejar la excepción
                Console.WriteLine($"Exception: {ex.Message}");
                // Devolver un error interno del servidor con el código 500 Internal Server Error
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
            }
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var listaLibros = _context.Libros.ToList();
                var listaMaterialBibliografico = _context.MaterialBibliograficos.ToList();
                LibroDTO libroBuscado = new LibroDTO();

                var query =
                    from libro in listaLibros
                    where libro.IdMaterialBibliografico == id
                    select new LibroDTO
                    {
                        Autor = libro.autor,
                        EditorialLibro = libro.editorialLibro,
                        Anio = libro.anio,
                        Titulo = libro.titulo,
                        Status = libro.status

                    };

                if(query.Any())
                {
                    foreach (var dato in query)
                    {
                        libroBuscado.Autor = dato.Autor;
                        libroBuscado.EditorialLibro = dato.EditorialLibro;
                        libroBuscado.Titulo = dato.Titulo;
                        libroBuscado.Anio = dato.Anio;
                        libroBuscado.Status = dato.Status;
                    }
                }else
                {
                    return Ok(new { Status = "Libro No encontrado"});
                }
                

                // Devolver una respuesta de éxito con la lista de libros y el código 200 OK
                return Ok(new { Status = "Success", Libro = libroBuscado });
            }
            catch (Exception ex)
            {
                // Log o manejar la excepción
                Console.WriteLine($"Exception: {ex.Message}");
                // Devolver un error interno del servidor con el código 500 Internal Server Error
                return StatusCode(500, new { Status = "Error", Message = "Error interno del servidor" });
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
                    // Crear un nuevo objeto Libro y asignarle los valores del DTO
                    var nuevoLibro = new Libro
                    {
                        autor = libroDTO.Autor,
                        titulo = libroDTO.Titulo,
                        anio = libroDTO.Anio,
                        status = libroDTO.Status,
                        editorialLibro = libroDTO.EditorialLibro
                    };

                    // Agregar el nuevo libro al contexto y guardar los cambios
                    _context.Libros.Add(nuevoLibro);
                    _context.SaveChanges();

                    // Devolver una respuesta de éxito con el nuevo libro creado
                    return Ok(new { Status = "Success", Message = "Libro creado exitosamente", Libro = libroDTO });
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

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
