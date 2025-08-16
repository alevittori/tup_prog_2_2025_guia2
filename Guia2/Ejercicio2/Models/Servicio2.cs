using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2.Models
{
    internal class Servicio2
    {
        public List<Persona2> personas = new List<Persona2>();

        public bool AgregarPersona(int dni, string nombre)
        {
            Persona2 nuevaPersona = new Persona2(dni, nombre);
            bool encontrado = false;

            //validamos que la persona no exista en la lista
            foreach(Persona2 persona in personas)
            {
                if(persona.DNI == nuevaPersona.DNI)
                {
                    encontrado = true;
                    MessageBox.Show("Esa persona ya existe ","Atencion!");
                    return false;
                }
            }
            
            
            if (!encontrado )
            {
                personas.Add(nuevaPersona);
                return true;
            }
            return false;
        }
        public int VerCantidadPersonas()
        {
            return personas.Count;
        }
        public Persona2 VerPersona(int indice)
        {
            if (indice >= 0 && indice < personas.Count)
            {
                return personas[indice];
            }
            return null;
        }

        public Persona2 VerPersonaPorDNI(int dni)
        {
            return personas.Find(p => p.DNI == dni);
        }

        public void EliminarPersona(Persona2 unaPersona)
        {
            personas.Remove(unaPersona);
        }
    }
}
