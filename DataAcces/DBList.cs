using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiMvc.DataAcces
{
    /// <summary>
    /// Classe <c>DBList</c>. Para la gestión de estructuras de datos.
    /// </summary>
    public class DBList
    {
        /// <summary>Transforma las filas de un datatable a una lista de objetos de una entidad.</summary>
        /// <param name="datatable">Objeto Datatable</param>
        /// <returns>Lista de objetos de la entidad definida</returns>
        public static List<T> ToList<T>(DataTable datatable) where T : IEntity, new()
        {
            List<T> entityList = new List<T>();
            foreach (DataRow dr in datatable.Rows)
            {
                T tp = new T();
                tp.SetFields(dr);
                entityList.Add(tp);
            }
            return entityList;
        }
    }
}