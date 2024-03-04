﻿using LibreriaORM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaORM.Data
{
    public class PrestamoDTO
    {

        public string fechaSalida { get; set; }
        public string fechaRegreso { get; set; }
        public int IdPersona { get; set; }
        public int IdMaterialBibliografico { get; set; }
        public Boolean statusPrestamo { get; set; }


    }
}
