using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public class Libro : MaterialBibliografico
    {
        
        public string editorialLibro { get; set; }
        public int IdMaterialBibliografico { set; get; }
        [ForeignKey("IdMaterialBibliografico")]
        public virtual MaterialBibliografico MaterialBibliografico {  get; set; }
        public Libro() 
        {
            tipoMaterial = tipoMaterial.Libro;
            
        }
    }
}
