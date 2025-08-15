using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class Servicio
    {
        List<Persona> personas = new List<Persona>();

        public bool AgregarPersona(Persona persona)
        {
            if (!personas.Contains(persona) && persona != null)
            {
                personas.Add(persona);
                return true;
            }
            return false;
        }
        public int VerCantidadPersonas()
        {
            return personas.Count;
        }
        public Persona VerPersona(int indice)
        {
            if(indice >=0 && indice < personas.Count)
            {
                return personas[indice];
            }
            return null;
        }

        public Persona VerPersonaPorDNI(int dni)
        {
            return personas.Find(p=> p.DNI == dni);
        }
    }
}
