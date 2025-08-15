using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Servicio servicio;
        public Form1()
        {
            InitializeComponent();
            servicio = new Servicio();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lboxResultado.Items.Clear();
            foreach(Persona p in servicio.personas)
            {
                lboxResultado.Items.Add(p.Describir());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FDatoPersona VDatosPersona = new FDatoPersona();

            if(VDatosPersona.ShowDialog() == DialogResult.OK)
            {
                int dni = int.Parse(VDatosPersona.tbDNI.Text); // hacer un control 
                string nombre = VDatosPersona.tbNombre.Text;
                Persona unaPersona = new Persona(dni, nombre);
                servicio.AgregarPersona(unaPersona);
                MessageBox.Show($" Se agrego:{unaPersona.Describir()}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {

            int indice = lboxResultado.SelectedIndex;
            if (indice != -1)
            {
                FDatoPersona VDatosPersona = new FDatoPersona();
                Persona unaPersona = servicio.VerPersona(indice);
                VDatosPersona.tbDNI.Text = unaPersona.DNI.ToString();
                VDatosPersona.tbNombre.Text = unaPersona.Nombre;
                VDatosPersona.ShowDialog();
                VDatosPersona.Dispose();
            }
            else
            {
                MessageBox.Show("DEBE SELECCIONA UNA PERSONA DE LA LISTA");
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = lboxResultado.SelectedIndex;
            if (indice != -1)
            {
                FDatoPersona VDatosPersona = new FDatoPersona();
                Persona unaPersona = servicio.VerPersona(indice);
                VDatosPersona.tbDNI.Text = unaPersona.DNI.ToString();
                VDatosPersona.tbNombre.Text = unaPersona.Nombre;
                if(VDatosPersona.ShowDialog()== DialogResult.OK)
                {
                    VDatosPersona.Text = "MODIFICAR DATOS";
                    int dni = int.Parse(VDatosPersona.tbDNI.Text);
                    string nombre = VDatosPersona.tbNombre.Text;
                    servicio.personas[indice] = new Persona(dni, nombre); // pisamos en ese indice con la nueva persona
                    lboxResultado.Items.Clear();
                }

                VDatosPersona.Dispose();
            }
            else
            {
                MessageBox.Show("DEBE SELECCIONA UNA PERSONA DE LA LISTA");
                return;
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
                    servicio.EliminarPersona(servicio.VerPersona(indice));
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
