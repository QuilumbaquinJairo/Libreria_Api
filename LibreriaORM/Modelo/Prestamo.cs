using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public class Prestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public string fechaSalida { get; set; }
        public string fechaRegreso { get; set; }
        public int IdPersona { get; set; }
        
        public int IdMaterialBibliografico { get; set; }
        

        public Persona Persona;
        public MaterialBibliografico MaterialBibliografico;

    }
}
