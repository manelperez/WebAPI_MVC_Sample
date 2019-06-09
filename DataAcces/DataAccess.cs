using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebApiMvc.DataAcces
{
    /// <summary>
    /// Classe <c>DataAccess</c>. Implementa la interfaz IDataAccess. 
    /// </summary>
    /// <remark>Implementa los métodos que  Acceden y manipulan los datos en la base de datos.</remark>
    class DataAccess : IDataAccess
    {
        /// <summary>Definición de la variable <c>_connectionString</c>.
        /// Representa la cadena de conexión para el acceso a la base de datos.</summary>
        public string _connectionString = WebApiMvc.Startup.ConnectionString;

        /// <summary>Constructor</summary>
        public DataAccess() { }

        public DataTable Read(string sql, List<DbParameter> dbParameters)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, connection);
                if (dbParameters != null)
                {
                    foreach (DbParameter p in dbParameters)
                        command.Parameters.Add(p);
                }
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception)
            { throw; }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public int CreateUpdateDelete(string sql, List<DbParameter> dbParameters)
        {
            int rows = 0;
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            // Se realiza la modificación mediante transacciones
            SqlTransaction transaction = connection.BeginTransaction("ReadTransaction");
            try
            {
                command.Transaction = transaction;
                if (dbParameters != null)
                {
                    foreach (SqlParameter p in dbParameters)
                        command.Parameters.Add(p);
                }
                rows = command.ExecuteNonQuery();
                // Se establece la modificación
                transaction.Commit();
            }
            catch (Exception)
            {
                // En caso de error, No se establece la modificación
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
            return rows;
        }
    }
}