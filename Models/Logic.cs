using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiMvc.DataAcces;

namespace WebApiMvc.Models
{
    /// <summary>
    /// Classe <c>Logic</c>. Modela la lógica de negocio.
    /// </summary>
    /// <remark>Gestiona las acciones que se pueden realizar</remark>
    public class Logic
    {
        /// <summary>Definición de la variable <c>_management</c>.
        /// Representa la gestión de los datos que se aplicará.</summary>
        IManagement _management = null;

        /// <summary>Constructor, inicializa una instancia de Management.</summary>
        public Logic()
        {
            _management = new Management() as IManagement;
        }

        /// <summary>Obtiene todos los productos</summary>
        /// <returns>Lista de productos</returns>
        public List<Product> GetAllProducts()
        {
            return _management.Products();
        }

        /// <summary>Obtiene el producto por su ID</summary>
        /// <param name="id">ID del producto</param>
        /// <returns>objeto de la clase producto</returns>
        public Product GetProductById(int id)
        {
            return _management.Product(id);
        }

        /// <summary>Añade un producto</summary>
        /// <param name="Product">objeto de la clase producto que se quiere añadir</param>
        public void AddProduct(Product Product)
        {
            Product.Id = 0;
            _management.CreateOrUpdateProduct(Product);
        }

        /// <summary>Modifica un producto</summary>
        /// <param name="id">ID del producto</param>
        /// <param name="Product">objeto de la clase producto que contiene los datos que se van a modificar</param>
        public void UpdateProduct(int id, Product Product)
        {
            Product.Id = id;
            _management.CreateOrUpdateProduct(Product);
        }

        /// <summary>Elimina un producto</summary>
        /// <param name="id">ID del producto</param>
        public void DeleteProduct(int id)
        {
            _management.DeleteProduct(id);
        }
    }
}