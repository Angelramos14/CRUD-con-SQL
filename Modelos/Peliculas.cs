using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
    
using System.Data.SqlClient;

namespace Modelos
{
    public class Peliculas
    {
        private int id;
        private string nombre;
        private string director;
        private DateTime fechaLanzamiento;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Director { get => director; set => director = value; }
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }

        public static DataTable CargarPeliculas()
        {
            SqlConnection con = Conexion.Conectar();

            string comando = "select * from Peliculas;";

            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            return dt;
        }

        public bool InsertarPeliculas()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = " Insert into peliculas(nombre,director,fechaLanzamiento)" + "values(@nombre, @director, @fechaLanzamiento);";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@director",director);
            cmd.Parameters.AddWithValue("@fechaLanzamiento", fechaLanzamiento);

            cmd.ExecuteNonQuery();

            if (cmd.ExecuteNonQuery()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ActualizarPeliculas()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "UPDATE peliculas set nombre=@nombre, director=@director, fechalanzamiento=@fecha where id_pelicula=@id";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre",nombre);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@fecha", fechaLanzamiento);
            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.ExecuteNonQuery()>0)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
        public bool EliminarPelicula()
        {
            try
            {
                SqlConnection con = Conexion.Conectar();
                string ConsultaDelete = "DELETE FROM Zapatos where id_pelicula=@id";
                SqlCommand delete = new SqlCommand(ConsultaDelete, con);
                delete.Parameters.AddWithValue("@id_pelicula=@id", id);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
