using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraDelBanco
{
    internal class Conexiones
    {
        public DataTable ConsultarBD(string nombreSP)
        {
            SqlConnection conexion = new SqlConnection(Properties.Resources.CadenaConexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand(nombreSP, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;

        }
        public int ActualizarBD(string nombreSP, List<Parametro> lista)
        {
            SqlConnection conexion = new SqlConnection(Properties.Resources.CadenaConexion);
            int filasAfectas = 0;
            conexion.Open();
            SqlCommand comando = new SqlCommand(nombreSP, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INSERT_BCO";
            foreach (Parametro param in lista)
            {
                comando.Parameters.AddWithValue(param.Nombre, param.Valor);

            }
            filasAfectas = comando.ExecuteNonQuery();
            conexion.Close();
            return filasAfectas;


            
            

        }
        
    }
}
