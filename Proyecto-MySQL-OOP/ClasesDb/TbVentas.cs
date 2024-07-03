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
    internal class TbVentas
    {
        public ConexionDb conexion = new ConexionDb();
        public MySqlCommand comando = new MySqlCommand();
        public MySqlDataReader LeerFilas;

        public DataTable ListarEmpleado()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarEmpleado";
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

        public void VerVentas(DataGridView TablaVentas)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from venta";
                TablaVentas.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dtv = new DataTable();
                adapter.Fill(dtv);
                TablaVentas.DataSource = dtv;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos de venta" + ex.ToString());
            }
        }
        public void insertarVentas(TextBox id_ventas, MaskedTextBox FechaVenta, TextBox Totalventa,int Representante,int ubicacion, TextBox comentarios,int producto)
        {
            try
            {

                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into venta (id_venta,fecha_venta,Total,id_rep_ventas,id_ubicacion,comentario,id_producto)" +
                "values ('" + id_ventas.Text + "','" + FechaVenta.Text + "','" + Totalventa.Text + "','"
                + Representante + "','"  + ubicacion + "','" + comentarios.Text  + "','" + producto + "');";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se inserto correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.cerrarconexion();
            }
            catch (MySqlException ex)
            {
                // Captura la excepción específica de MySQL relacionada con la duplicación de claves primarias
                if (ex.Number == 1062) // El código de error 1062 indica una violación de clave única
                {
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_venta", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void seleccionarVentas(DataGridView TablaVentas,TextBox id_ventas, MaskedTextBox FechaVenta, TextBox Totalventa, ComboBox Representante, ComboBox ubicacion, TextBox comentarios,ComboBox producto)
        {
            try
            {
                id_ventas.Text = TablaVentas.CurrentRow.Cells[0].Value.ToString();
                FechaVenta.Text = TablaVentas.CurrentRow.Cells[1].Value.ToString();
                Totalventa.Text = TablaVentas.CurrentRow.Cells[2].Value.ToString();
                Representante.Text = TablaVentas.CurrentRow.Cells[3].Value.ToString();
                comentarios.Text = TablaVentas.CurrentRow.Cells[4].Value.ToString();
                ubicacion.Text = TablaVentas.CurrentRow.Cells[5].Value.ToString();
                producto.Text = TablaVentas.CurrentRow.Cells[6].Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void ConsultarDetalleV(TextBox id_venta, TextBox id_producto, TextBox cantidad, TextBox precio, TextBox Total)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                TbProductos objetoProducto = new TbProductos();
                string consulta = "SELECT id_producto, cant, precio, FORMAT(precio * cant, 2) AS total FROM detalle_venta WHERE id_venta = @idVenta";
                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MiComando.Parameters.AddWithValue("@idVenta", id_venta.Text);
                MySqlDataReader registros = MiComando.ExecuteReader();

                if (registros.Read())
                {
                    // Mostrar los datos en los TextBox y ComboBox correspondientes
                    id_producto.Text = registros["id_producto"].ToString();
                    cantidad.Text = registros["cant"].ToString();
                    precio.Text = registros["precio"].ToString();
                    Total.Text = registros["total"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró una venta con el ID proporcionado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void modificarVentas(TextBox id_ventas, MaskedTextBox FechaVenta, TextBox Totalventa, int Representante, int ubicacion, TextBox comentarios, int producto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update venta set fecha_venta='"
                + FechaVenta.Text   + "', total='" + Totalventa.Text +
                "', id_rep_ventas='" + Representante  + "', id_ubicacion='" + ubicacion + "', comentario='"+ comentarios.Text + "' where id_venta='" + id_ventas.Text + "', id_producto='"+producto+"';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se modificaron los datos de la venta" + ex.ToString());
            }
        }
        public void eliminarVentas(TextBox id_ventas)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from venta where id_venta='" + id_ventas.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos de la venta" + ex.ToString());
            }
        }
    }
}
