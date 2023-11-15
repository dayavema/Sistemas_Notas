using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotas.Modelo_de_clases
{
    internal class Boletin
    {
        public string Estudiante { get; set; }
        public string Materia { get; set; }

        private double _nota;
        private double _promedio;


        public double Nota
        {
            get { return _nota; }
            set
            {
                if (value >= 0 && value <= 5)
                {
                    _nota = value;
                }
                else
                {
                    // Puedes mostrar un mensaje de error o tomar otra acción aquí si la nota está fuera de rango.
                    _nota = 0; // Establecemos un valor por defecto.
                }
            }
        }

        public double Promedio
        {
            get { return _promedio; }
            set
            {
                if (value >= 0 && value <= 5)
                {
                    _promedio = value;
                }
                else
                {
                    // Puedes mostrar un mensaje de error o tomar otra acción aquí si el promedio está fuera de rango.
                    _promedio = 0; // Establecemos un valor por defecto.
                }
            }
        }
    }
}
