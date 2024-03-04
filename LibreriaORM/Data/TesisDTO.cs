using System.ComponentModel.DataAnnotations;

namespace LibreriaORM.Data
{
    public class TesisDTO
    {
        [Required(ErrorMessage = "El campo Autor es requerido")]
        [StringLength(50, ErrorMessage = "El campo Autor no puede tener más de 50 caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El campo Título es requerido")]
        [StringLength(50, ErrorMessage = "El campo Título no puede tener más de 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo Año es requerido")]
        [Range(1000, 2024, ErrorMessage = "El campo Año debe ser un valor entre 1000 y el año actual")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El campo Status es requerido")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "El campo ISBN es requerido")] // Agrega esta línea
        public string ISBN { get; set; } // Agrega esta línea
    }
}
