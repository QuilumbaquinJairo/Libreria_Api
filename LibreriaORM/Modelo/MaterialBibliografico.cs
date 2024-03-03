using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public abstract class MaterialBibliografico
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaterialBibliografico { set; get; }
        public tipoMaterial tipoMaterial { set; get; }
        public string autor { set; get; }
        public string titulo { set; get; }
        public int anio { set; get; }
        public Boolean status { set; get; }
        Libro Libro { set; get; }   
        Tesis Tesis { set; get; }
        Revista Revista { set; get; }
        Prestamo Prestamo { set; get; }
    }
    public enum tipoMaterial
    {
        Tesis,
        Revista,
        Libro
    }
}
