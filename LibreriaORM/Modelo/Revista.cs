using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public class Revista : MaterialBibliografico
    {
        
        public string EditorialRevista { get; set; }
        public int IdMaterialBibliografico { set; get; }
        [ForeignKey("IdMaterialBibliografico")]
        public virtual MaterialBibliografico MaterialBibliografico { get; set; }

        public Revista() 
        {
            tipoMaterial = tipoMaterial.Revista;
        }
    }
}
