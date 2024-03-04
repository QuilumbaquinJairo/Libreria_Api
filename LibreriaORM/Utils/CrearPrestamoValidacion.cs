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

        public Boolean validarHistorial(int idPersona,List<Prestamo>? listaprestamos)
        {
            var flag = false;
            var query =
                from prestamo in listaprestamos
                where prestamo.IdPersona == idPersona && prestamo.statusPrestamo == true
                select prestamo;
            var fechaValidar = query.First().fechaRegreso;
            var fecha = DateTime.Parse(fechaValidar);

            if (query.Any() && query.Count() <= 3)
            {
                flag = true;
            }

            return flag;
        }
        

    }
}
