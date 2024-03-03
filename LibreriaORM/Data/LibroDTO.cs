using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Data
{
    public class LibroDTO
    {
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public Boolean Status { get; set; }
        public string EditorialLibro { get; set; }
    }
}
