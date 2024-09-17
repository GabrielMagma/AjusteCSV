using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaCSV
{
    public class Register
    {
        public int CodigoEstacion { get; set; }

        public string NombreEstacion { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public int Altitud { get; set; }

        public string Departamento { get; set; }

        public string Municipio { get; set; }

        public string IdParametro { get; set; }

        public string Frecuencia { get; set; }

        public string Fecha { get; set; }

        public double Valor { get; set; }

    }
}
