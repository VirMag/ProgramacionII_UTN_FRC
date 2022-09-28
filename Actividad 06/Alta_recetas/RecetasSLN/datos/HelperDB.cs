using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN;
using static System.Net.Mime.MediaTypeNames;

public class HelperDB
    {
        private static HelperDB instancia;
        private SqlConnection cnn;
        
        private HelperDB()
        {
            cnn = new SqlConnection(RecetasSLN.Properties.Resources.String1);
        }
        public static  HelperDB ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia=new HelperDB();
            }
        return instancia;
        }
         public bool InsertarReceta(Receta nuevaRe)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                SqlCommand cmdMaestro = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();

                cmdMaestro.Connection = cnn;
                cmdMaestro.Transaction = t;
                cmdMaestro.CommandText = "SP_INSERTAR_RECETA";
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                cmdMaestro.Parameters.AddWithValue("@NombreReceta", nuevaRe.NombreReceta);
                cmdMaestro.Parameters.AddWithValue("@TipoReceta", nuevaRe.TipoReceta);
                cmdMaestro.Parameters.AddWithValue("@Cheff", nuevaRe.Cheff);


                SqlParameter NroRe = new SqlParameter();
                NroRe.ParameterName = "@RecetaNro";
                NroRe.DbType = DbType.Int32;
                NroRe.Direction = ParameterDirection.Output;

                cmdMaestro.Parameters.Add(NroRe);
                cmdMaestro.ExecuteNonQuery();

                int NroReceta = (int)NroRe.Value;


            SqlCommand cmdDetalle = new SqlCommand();
            int NroDetalle = 1;
            foreach (DetalleReceta item in nuevaRe.Detalles)
                {
                    

                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = t;
                    cmdDetalle.CommandText = "SP_INSERTAR_DETALLES";
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@RecetaNro", NroReceta);
                    cmdDetalle.Parameters.AddWithValue("@NroDetalle", NroDetalle);
                    cmdDetalle.Parameters.AddWithValue("@ingrediente", item.Ingrediente.IngredienteID);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);

                cmdDetalle.ExecuteNonQuery();
                NroDetalle++;
                }
            t.Commit();

            }
        catch (Exception)
        {
            if(t !=null)
            {
                t.Rollback();
                ok = false;
            }

        }
        finally
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        return ok;
        }
    }



