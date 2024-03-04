using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibreriaORM.Modelo
{
    public class Usuario : Persona
    {
     
        public string Facultad { get; set; }
        public int IdPersona { get; set; }
        public virtual Persona Persona { get; set; }
        public Usuario()
        {
            Rol = RolEnum.Usuario;
            sancion = false;
        }

    }
}
