using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Data
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Sancion { get; set; }
        public string Facultad { get; set; }
    }
}
