using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public class Tesis : MaterialBibliografico
    {
        
        
        [ForeignKey("IdMaterialBibliografico")]
        public virtual MaterialBibliografico MaterialBibliografico { get; set; }
        public Tesis() 
        {
            tipoMaterial = tipoMaterial.Tesis;
        }
    }
}
