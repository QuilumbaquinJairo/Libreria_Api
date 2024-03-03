using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public abstract class MaterialBibliografico
    {

        [Key]
        public int idMaterialBibliografico { set; get; }
        public string tipoMaterial { set; get; }
        public string autor { set; get; }
        public string titulo { set; get; }
        public int anio { set; get; }
        public string status { set; get; }


    }
}
