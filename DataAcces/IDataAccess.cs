using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebApiMvc.DataAcces
{
    /// <summary>
    /// Interfaz <c>IDataAccess</c>. Accede y manipula los datos en la base de datos.
    /// </summary>
    interface IDataAccess
    {
        /// <summary>Lectura de datos en la base de datos</summary>
        /// <param name="sql">Sentencia SQL con la consulta de selección</param>
        /// <param name="dbParameters">Parámetros correspondientes a los valores de cada campo para la consulta</param>
        /// <returns>objeto DataTable con las filas y columnas obtenidas</returns>
        DataTable Read(string sql, List<DbParameter> dbParameters);

        /// <summary>Modificación de datos en la base de datos</summary>
        /// <param name="sql">Sentencia SQL con los comandos de inserción, actualización y eliminación</param>
        /// <param name="dbParameters">Parámetros correspondientes a los valores de cada campo para la consulta</param>
        /// <returns>Número de filas afectadas</returns>
        int CreateUpdateDelete(string sql, List<DbParameter> dbParameters);
    }
}