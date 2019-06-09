using System.Collections.Generic;
using WebApiMvc.Models;

namespace WebApiMvc.DataAcces
{
    /// <summary>
    /// Interfaz <c>IManagement</c>. Prepara los datos para realizar las acciones de CRUD.
    /// </summary>
    public interface IManagement
    {
        /// <summary>Obtiene todos los productos</summary>
        /// <returns>Lista de productos</returns>
        List<Product> Products();

        /// <summary>Obtiene el producto por su ID</summary>
        /// <param name="id">ID del producto</param>
        /// <returns>objeto de la clase Producto</returns>
        Product Product(int id);

        /// <summary>Añade o Modifica un producto, según convenga</summary>
        /// <param name="Product">objeto de la clase Producto que contiene los datos que se van a modificar</param>
        int CreateOrUpdateProduct(Product Product);

        /// <summary>Elimina un producto</summary>
        /// <param name="id">ID del producto</param>
        int DeleteProduct(int id);
    }
}