using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotas.Modelo_de_clases
{
    public class Materias
    {

            public string Nombre { get; set; }
            public int Creditos { get; set; }
            // Agrega más propiedades según sea necesario

            public override string ToString()
            {
                return $"{Nombre},{Creditos}";
            }
    }
}
