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
    public partial class FrmPuesto : Form
    {
        public FrmPuesto()
        {
            InitializeComponent();
            ClasesDb.Tbs_Foraneas objetoPuesto = new ClasesDb.Tbs_Foraneas();
            objetoPuesto.VerPuesto(dtgPuestos);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Frm1 obj = new Frm1();
            this.Hide();
            obj.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoPuesto = new ClasesDb.Tbs_Foraneas();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_Puesto: {txtId_Puesto.Text}\r\nNombre:{txtNombre.Text}\r\nSueldo:{txtSueldo.Text}\r\nComentarios:{txtComentarios.Text}\r\n";
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
            objetoPuesto.insertarPuesto(txtId_Puesto,txtNombre,txtSueldo,txtComentarios);
            objetoPuesto.VerPuesto(dtgPuestos);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoPuesto = new ClasesDb.Tbs_Foraneas();
            objetoPuesto.modificarPuesto(txtId_Puesto,txtNombre, txtSueldo, txtComentarios);
            objetoPuesto.VerPuesto(dtgPuestos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoPuesto = new ClasesDb.Tbs_Foraneas();
            objetoPuesto.eliminarPuesto(txtId_Puesto);
            objetoPuesto.VerPuesto(dtgPuestos);
        }

        private void dtgPuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoPuesto = new ClasesDb.Tbs_Foraneas();
            objetoPuesto.seleccionarPuesto(dtgPuestos,txtId_Puesto,txtNombre,txtSueldo,txtComentarios);
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtId_Puesto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtComentarios_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmPuesto_Load(object sender, EventArgs e)
        {

        }
    }
}
