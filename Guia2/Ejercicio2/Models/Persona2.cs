using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Persona2
    {

        public int DNI { get; private set; }
        public string Nombre { get; private set; }

        public Persona2(int dni, string nombre)
        {
            DNI = dni;
            Nombre = nombre;
        }

        public string Describir()
        {
            return $"{DNI} - {Nombre}";
        }
    }
}
