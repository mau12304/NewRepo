using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP.ClasesDb
{
    internal class TbInventario
    {
        public ConexionDb conexion = new ConexionDb();
        public MySqlCommand comando = new MySqlCommand();
        public MySqlDataReader LeerFilas;

        public DataTable ListarProducto()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.cerrarconexion();
            return tabla;
        }
        public DataTable ListarAreas()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarAreas";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.cerrarconexion();
            return tabla;
        }

        public void VerInventario(DataGridView TablaInventario)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from inventario";
                TablaInventario.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dti = new DataTable();
                adapter.Fill(dti);
                TablaInventario.DataSource = dti;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos del inventario" + ex.ToString());
            }
        }
        public void insertarInventario(int id_producto, TextBox CanStock,TextBox CanMax, TextBox CanMin, TextBox Comentario, MaskedTextBox Fecha_reorden, int ubicacion)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into inventario (id_producto,cant_stock,Cant_max,Cant_min,comentario,Fecha_reorden,id_ubicacion)" +
                "values ('" + id_producto + "','" + CanStock.Text + "','" + CanMax.Text + "','" + CanMin.Text + "','"+ Comentario.Text + "','"+ Fecha_reorden.Text + "','" +ubicacion + "');";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se inserto correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos de inventario" + ex.ToString());
            }
        }
        public void seleccionarInventario(DataGridView TablaInventario,ComboBox id_producto, TextBox CanStock, TextBox CanMax, TextBox CanMin, TextBox Comentario, MaskedTextBox Fecha_reorden, ComboBox ubicacion)
        {
            try
            {
                id_producto.Text = TablaInventario.CurrentRow.Cells[0].Value.ToString();
                ubicacion.Text = TablaInventario.CurrentRow.Cells[1].Value.ToString();
                CanStock.Text = TablaInventario.CurrentRow.Cells[2].Value.ToString();
                CanMax.Text = TablaInventario.CurrentRow.Cells[3].Value.ToString();
                CanMin.Text = TablaInventario.CurrentRow.Cells[4].Value.ToString();
                Comentario.Text = TablaInventario.CurrentRow.Cells[5].Value.ToString();
                Fecha_reorden.Text = TablaInventario.CurrentRow.Cells[6].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void modificarInventario(int id_producto, TextBox CanStock, TextBox CanMax, TextBox CanMin, TextBox Comentario, MaskedTextBox Fecha_reorden, int ubicacion)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update inventario set Cant_stock='"
                + CanStock.Text + "', Cant_Max='" + CanMax.Text +
                "', Cant_Min='" + CanMin.Text + "', Comentario='" + Comentario.Text +
                "', fecha_reorden='" + Fecha_reorden.Text + "', id_ubicacion='"+ubicacion + "' where id_producto ='" + id_producto + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader reader = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se modificaron los datos del inventario" + ex.ToString());
            }
        }
        public void eliminarInventario(ComboBox id_producto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from inventario where id_producto='" + id_producto.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos del inventario" + ex.ToString());
            }
        }
    }
}
