using Ejercicio2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2 
{
    
    public partial class Form1 : Form
    {
        Servicio2 unServicio;
        public Form1()
        {
            InitializeComponent();
            unServicio = new Servicio2();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lboxResultado.Items.Clear();
            foreach(Persona2 persona in unServicio.personas)
            {
                lboxResultado.Items.Add(persona.Describir());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FDatosPersona2 VDatosPersona = new FDatosPersona2();

            if (VDatosPersona.ShowDialog() == DialogResult.OK)
            {
                int dni = int.Parse(VDatosPersona.tbDNI.Text);
                string nombre = VDatosPersona.tbNombre.Text;
                bool agreda = unServicio.AgregarPersona(dni, nombre);
                
                if(agreda)
                {
                    MessageBox.Show("Persona Agregada", "Exito!");

                }
                //else
                //{
                //    MessageBox.Show("")
                //}
            }
            VDatosPersona.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            int indice = lboxResultado.SelectedIndex;
            if(indice != -1) 
            {
                Persona2 personaVer = unServicio.VerPersona(indice);
                FDatosPersona2 VDatosPersona = new FDatosPersona2();
                VDatosPersona.tbDNI.Text = personaVer.DNI.ToString();
                VDatosPersona.tbNombre.Text = personaVer.Nombre;

                VDatosPersona.ShowDialog();
                VDatosPersona.Dispose();

            }
            else
            {
                MessageBox.Show("Debes Seleccionar uno de la lista", "Atencion!");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = lboxResultado.SelectedIndex;
            if(indice != -1)
            {
                FDatosPersona2 VDatosPersona = new FDatosPersona2();
                VDatosPersona.tbDNI.Text = unServicio.personas[indice].DNI.ToString();
                VDatosPersona.tbNombre.Text = unServicio.personas[indice].Nombre;

                if(VDatosPersona.ShowDialog() == DialogResult.OK)
                {
                    int dni = int.Parse(VDatosPersona.tbDNI.Text); // hacer control para que solo ingrese numero
                    string nombre = VDatosPersona.tbNombre.Text;
                    Persona2 personaModificada = new Persona2(dni,nombre);
                    unServicio.personas[indice] = personaModificada; // piso la lista en el indice seleccionado con la nueva persona modificada

                    lboxResultado.Items.Clear();
                }

            }
            else
            {
                MessageBox.Show("Debes Seleccionar uno de la lista", "Atencion!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = lboxResultado.SelectedIndex;
            if (indice != -1)
            {
                DialogResult result = MessageBox.Show("Desea Eliminar la Persona?", "Eliminar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    unServicio.EliminarPersona(unServicio.VerPersona(indice));
                    MessageBox.Show("Persona Eliminada", "Exito!");
                    lboxResultado.Items.Clear();

                }


            }
            else
            {
                MessageBox.Show("DEBE SELECCIONA UNA PERSONA DE LA LISTA");
                return;
            }
        }
    }
}
