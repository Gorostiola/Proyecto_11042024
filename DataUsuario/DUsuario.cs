using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DataUsuario
{
    public class DUsuario
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable Obtener()
        {
            SqlCommand cmd = new SqlCommand("SpObtenerUsuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Buscar(string valor)
        {
            SqlCommand cmd = new SqlCommand("SpBuscarUsuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Valor", valor);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataRow ObtenerId(int id)
        {
            SqlCommand cmd = new SqlCommand("SpObtenerIdUsuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];

        }


        public int Agregar(string Nombre, string ApellidoP, string ApellidoM, string Fecha)
        {
            SqlCommand cmd = new SqlCommand("SpAgregarUsuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nom", Nombre);
            cmd.Parameters.AddWithValue("@App", ApellidoP);
            cmd.Parameters.AddWithValue("@Apm", ApellidoM);
            cmd.Parameters.AddWithValue("@Fecha", Fecha);

            try
            {
                con.Open();
                int fa = cmd.ExecuteNonQuery();
                con.Close();
                return fa;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public int Editar(string Nombre, string ApellidoP, string ApellidoM, string Fecha, int Id)
        {
            SqlCommand cmd = new SqlCommand("SpEditarUsuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nom", Nombre);
            cmd.Parameters.AddWithValue("@App", ApellidoP);
            cmd.Parameters.AddWithValue("@Apm", ApellidoM);
            cmd.Parameters.AddWithValue("@Fecha", Fecha);
            cmd.Parameters.AddWithValue("@Id", Id);

            try
            {
                con.Open();
                int fa = cmd.ExecuteNonQuery();
                con.Close();
                return fa;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }


        public int Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("SpEliminarUsuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                con.Open();
                int fa = cmd.ExecuteNonQuery();
                con.Close();
                return fa;
            }
            catch (Exception ex)
            {
                con.Close();
                throw;
            }
        }

    }
}
