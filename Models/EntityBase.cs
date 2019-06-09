using System;
using System.Data;
using System.Reflection;
using WebApiMvc.DataAcces;

namespace WebApiMvc.Models
{
    /// <summary>
    /// Declaración de la clase <c>EntityBase</c>. Implementa la interfaz IEntity.
    /// </summary>
    public class EntityBase : IEntity
    {
        /// <summary>Implementa el método SetFields. A partir de un DataRow se establece un objeto de la clase derivada</summary>
        /// <param name="dr">Objeto Datarow a tratar</param>
        public void SetFields(DataRow dr)
        {
            Type tp = this.GetType();
            foreach (PropertyInfo pi in tp.GetProperties())
            {
                if (pi != null && pi.CanWrite)
                {
                    string nm = pi.PropertyType.Name.ToUpper();
                    if (pi.PropertyType.Name.ToUpper() != "BINARY")
                        pi.SetValue(this, dr[pi.Name], null);
                }
            }
        }
    }
}