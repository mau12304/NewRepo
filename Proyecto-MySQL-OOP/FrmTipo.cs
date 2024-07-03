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
    public partial class FrmTipo : Form
    {
        public FrmTipo()
        {
            InitializeComponent();
            ClasesDb.Tbs_Foraneas objetoTipo = new ClasesDb.Tbs_Foraneas();
            objetoTipo.VerTipo(dtgTipo);
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

        private void FrmTipo_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoTipo = new ClasesDb.Tbs_Foraneas();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_tipo: {txtId_Tipo.Text}\r\nNombre:{txtNombre.Text}\r\n";
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

            objetoTipo.insertarTipo(txtId_Tipo, txtNombre);
            objetoTipo.VerTipo(dtgTipo);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoTipo = new ClasesDb.Tbs_Foraneas();
            objetoTipo.modificarTipo(txtId_Tipo, txtNombre);
            objetoTipo.VerTipo(dtgTipo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoTipo = new ClasesDb.Tbs_Foraneas();
            objetoTipo.eliminarTipo(txtId_Tipo);
            objetoTipo.VerTipo(dtgTipo);
        }

        private void dtgTipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoTipo = new ClasesDb.Tbs_Foraneas();
            objetoTipo.seleccionarTipo(dtgTipo,txtId_Tipo,txtNombre);
            
        }

        private void txtId_Tipo_KeyPress(object sender, KeyPressEventArgs e)
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
