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
    public partial class FrmModelo : Form
    {
        public FrmModelo()
        {
            InitializeComponent();
            ClasesDb.Tbs_Foraneas objetoModelo = new ClasesDb.Tbs_Foraneas();
            objetoModelo.VerModelo(dtgModelo);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmProd objregresar = new FrmProd();
            this.Hide();
            objregresar.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmModelo_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoModelo = new ClasesDb.Tbs_Foraneas();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_modelo: {txtId_Modelo.Text}\r\nNombre:{txtNombre.Text}\r\n";
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
            objetoModelo.insertarModelo(txtId_Modelo, txtNombre);
            objetoModelo.VerModelo(dtgModelo);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoModelo = new ClasesDb.Tbs_Foraneas();
            objetoModelo.modificarModelo(txtId_Modelo, txtNombre);
            objetoModelo.VerModelo(dtgModelo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoModelo = new ClasesDb.Tbs_Foraneas();
            objetoModelo.eliminarModelo(txtId_Modelo);
            objetoModelo.VerModelo(dtgModelo);
        }

        private void dtgModelo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.Tbs_Foraneas objetoModelo = new ClasesDb.Tbs_Foraneas();
            objetoModelo.seleccionarModelo(dtgModelo,txtId_Modelo,txtNombre);
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

        private void txtId_Modelo_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
