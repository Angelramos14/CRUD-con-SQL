using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Reflection.Emit;

namespace Modelos
{
    internal class Conexion
    {
        private static string servidor = "DESKTOP-JVGVM0A\\SQLEXPRESS";
        private static string baseDeDatos = "CRUD20250443";

        public static SqlConnection Conectar()
        {
            string cadena =
                $"Data Source={servidor};" +
                $" Initial Catalog={baseDeDatos};" +
                $" Integrated Security=true;";

            SqlConnection con = new SqlConnection(cadena);
            con.Open();
            return con;
        }
    }
}
