using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public class Prestamo
    {
        public int id { get; set; }
        public string fechaSalida { get; set; }
        public string fechaRegreso { get; set; }
        public int idPersona { get; set; }
        public int idMaterialBibliografico { get; set; }

        public Persona persona;
        public MaterialBibliografico materialBibliografico;

    }
}
