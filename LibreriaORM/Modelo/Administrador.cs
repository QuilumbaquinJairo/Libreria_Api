using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Modelo
{
    public class Administrador : Persona
    {
        
        
        public string privilegios { get; set; }
        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
        public Administrador()
        {
            Rol = RolEnum.Administrador;
        }
    }
}
