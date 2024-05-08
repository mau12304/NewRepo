using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP
{
    public partial class FrmAreas : Form
    {
        public FrmAreas()
        {
            InitializeComponent();
            ClasesDb.Tbs_Foraneas objetoAreas = new ClasesDb.Tbs_Foraneas();
            objetoAreas.VerAreas(dtgAreas);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmVentas objregresar = new FrmVentas();
            this.Hide();
            objregresar.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmAreas_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoAreas = new ClasesDb.Tbs_Foraneas();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_Area: {txtId_Area.Text}\r\nNombre:{txtNombre.Text}\r\nSeccion:{txtSeccion.Text}\r\n";
            string rutaArchivo = "C:\\emu8086\\vdrive\\C\\Prueba\\Archivo.txt";

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                if (File.Exists(rutaArchivo))
                {
                    writer.WriteLine(datos);
                }
                else
                {
                    File.WriteAllText(rutaArchivo, datos);
                }
            }
            objetoAreas.insertarAreas(txtId_Area,txtNombre,txtSeccion);
            objetoAreas.VerAreas(dtgAreas);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoAreas = new ClasesDb.Tbs_Foraneas();
            objetoAreas.modificarAreas(txtId_Area, txtNombre, txtSeccion);
            objetoAreas.VerAreas(dtgAreas);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoAreas = new ClasesDb.Tbs_Foraneas();
            objetoAreas.eliminarAreas(txtId_Area);
            objetoAreas.VerAreas(dtgAreas);
        }

        private void dtgAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoAreas = new ClasesDb.Tbs_Foraneas();
            objetoAreas.seleccionarAreas(dtgAreas,txtId_Area,txtNombre,txtSeccion);
        }

        private void txtId_Area_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
        if (Char.IsControl(e.KeyChar))//Permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;//El resto de teclas pulsadas se desactivan
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) // Permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // El resto de teclas pulsadas se desactivan
            }
        }
    }
}
