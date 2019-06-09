using System.Data;

namespace WebApiMvc.DataAcces
{
    /// <summary>
    /// Interfaz <c>IEntity</c>. Derivará a una clase específica.
    /// </summary>
    public interface IEntity
    {
        /// <summary>A partir de un DataRow se establece un objeto de la clase derivada.</summary>
        void SetFields(DataRow dr);
    }
}