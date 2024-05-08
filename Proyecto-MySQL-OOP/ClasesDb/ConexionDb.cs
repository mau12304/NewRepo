using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP.ClasesDb
{
    internal class ConexionDb
    {

        MySqlConnection conexion = new MySqlConnection();
        static string servidor = "localhost";
        static string Bd = "Store_JAMST";
        static string usuario = "root";
        static string password = "mau060602";
        static string puerto = "3306";

        string cadenaconexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + Bd + ";";

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                conexion.ConnectionString = cadenaconexion;
                conexion.Open();
                //MessageBox.Show("Se conecto a la base dato");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la base dato, error:" + ex.ToString());
            }
            return conexion;
        }
        public void cerrarconexion()
        {
            conexion.Close();
        }
    }
}
