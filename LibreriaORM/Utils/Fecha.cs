using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Utils
{
    public class Fecha
    {
        public DateTime fechaSalida { get; set; }
        public DateTime fechaRegreso { get; set; }
        public Fecha()
        {
            fechaSalida = DateTime.Now;
            fechaRegreso = CalcularDiaRegreso(fechaSalida);
        }
        public DateTime CalcularDiaRegreso(DateTime fechaSalida)
        {
            // Número de días hábiles a sumar
            int diasHabiles = 4;

            // Loop para sumar días hábiles
            while (diasHabiles > 0)
            {
                fechaSalida = fechaSalida.AddDays(1);

                // Verificar si la fecha actual es un día de semana (lunes a viernes)
                if (fechaSalida.DayOfWeek != DayOfWeek.Saturday && fechaSalida.DayOfWeek != DayOfWeek.Sunday)
                {
                    // Si es un día hábil, restar uno al contador de días hábiles
                    diasHabiles--;
                }
            }

            return fechaSalida;
        }
    }
}
