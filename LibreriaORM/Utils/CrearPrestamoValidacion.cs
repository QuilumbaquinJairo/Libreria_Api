using LibreriaORM.Data;
using LibreriaORM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Utils
{
    public class CrearPrestamoValidacion
    {
        public Boolean validarPersona(List<Persona> listaUsuarios, int idPersona)
        {
            Boolean flag = false;
            var query =
                from usuario in listaUsuarios
                where usuario.IdPersona == idPersona
                select usuario;
            if (query.Any())
            {
                flag = true;
            }
            return flag;
        }
        public Boolean validarLibro(List<MaterialBibliografico> listalibro, int idMaterial)
        {
            Boolean flag = false;
            var query =
                from libro in listalibro
                where libro.IdMaterialBibliografico == idMaterial && libro.status  == true
                select libro;
            if (query.Any())
            {
                flag = true;
            }
            return flag;
        }
    }
}
