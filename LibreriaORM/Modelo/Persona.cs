using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public bool sancion { get; set; }
        public RolEnum Rol { get; set; }
        public string contrasenia {  get; set; }
        
        public Usuario? Usuario { get; set; }
        public Administrador? Administrador { get; set; }
        public List<Prestamo> Prestamo { set; get; }
    }
    public enum RolEnum
    {
        Usuario,
        Administrador
    }
}
