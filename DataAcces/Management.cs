using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using WebApiMvc.Models;

namespace WebApiMvc.DataAcces
{
    /// <summary>
    /// Classe <c>Management</c>. Implementa la interfaz IManagement. 
    /// </summary>
    /// <remark>Implementa los métodos que preparan los datos para realizar las acciones de CRUD</remark>
    class Management : IManagement
    {
        /// <summary>Definición de la variable <c>_dataAccess</c>.
        /// Representa el acceso y manipulación de la base de datos.</summary>
        IDataAccess _dataAccess = null;

        /// <summary>Constructor, inicializa una instancia de DataAccess.</summary>
        public Management()
        {
            _dataAccess = new DataAccess();
        }

        public List<Product> Products()
        {
            try
            {
                List<Product> ct = null;
                try
                {
                    // Se prepara la consulta de selección
                    // y se convierten los datos obtenidos en una lista de productos.
                    string sql = "SELECT * FROM dbo.Products";
                    List<DbParameter> ParamList = new List<DbParameter>();
                    DataTable dt = _dataAccess.Read(sql, ParamList);
                    ct = DBList.ToList<Product>(dt);
                }
                catch (Exception)
                {
                    throw;
                }
                return ct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product Product(int id)
        {
            try
            {
                Product Product = null;
                try
                {
                    // Se prepara la consulta de selección para obtener un único producto,
                    // el especificado por su ID.
                    string sql = "SELECT * FROM dbo.Products WHERE Id = @Id";
                    List<DbParameter> ParamList = new List<DbParameter>();
                    SqlParameter p1 = new SqlParameter("@Id", SqlDbType.VarChar);
                    p1.Value = id;
                    ParamList.Add(p1);
                    DataTable dt = _dataAccess.Read(sql, ParamList);
                    if (dt.Rows.Count > 0)
                    { Product = DBList.ToList<Product>(dt).First(); }
                }
                catch (Exception)
                {
                    throw;
                }
                return Product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CreateOrUpdateProduct(Product product)
        {
            int res = 0;
            try
            {
                string sql = String.Empty;

                if (product.Id > 0)
                {
                    // En el caso de que el producto obtenido tenga un ID, se preparan los datos del producto para ese ID.
                    sql = "UPDATE dbo.Products SET GroupCode = @GroupCode, CreatedOn = @CreatedOn, DeletedOn = @DeletedOn, Material = @Material, Weight = @Weight, Shape = @Shape, Appearance = @Appearance, Examination = @Examination, Volume = @Volume, Value = @Value, Quantity = @Quantity, NumParts = @NumParts, NumOperations = @NumOperations, Protection = @Protection WHERE Id = @Id";
                }
                else
                {
                    // En el caso de que el producto obtenido tenga ID=0, se prepara un nuevo producto con los datos.
                    sql = "INSERT INTO dbo.Products (GroupCode, CreatedOn, DeletedOn, Material, Weight, Shape, Appearance, Examination, Volume, Value, Quantity, NumParts, NumOperations, Protection) VALUES (@GroupCode, @CreatedOn, @DeletedOn, @Material, @Weight, @Shape, @Appearance, @Examination, @Volume, @Value, @Quantity, @NumParts, @NumOperations, @Protection)";
                }

                // Se asignan los valores de cada campo.
                List<DbParameter> ParamList = new List<DbParameter>();
                SqlParameter p1 = new SqlParameter("@Id", SqlDbType.VarChar, 4);
                p1.Value = product.Id;
                ParamList.Add(p1);
                SqlParameter p2 = new SqlParameter("@GroupCode", SqlDbType.VarChar, 4);
                p2.Value = product.GroupCode;
                ParamList.Add(p2);
                SqlParameter p3 = new SqlParameter("@CreatedOn", SqlDbType.VarChar, 19);
                p3.Value = product.CreatedOn;
                ParamList.Add(p3);
                SqlParameter p4 = new SqlParameter("@DeletedOn", SqlDbType.VarChar, 19);
                p4.Value = product.DeletedOn;
                ParamList.Add(p4);
                SqlParameter p5 = new SqlParameter("@Material", SqlDbType.VarChar, 50);
                p5.Value = product.Material;
                ParamList.Add(p5);
                SqlParameter p6 = new SqlParameter("@Weight", SqlDbType.VarChar, 50);
                p6.Value = product.Weight;
                ParamList.Add(p6);
                SqlParameter p7 = new SqlParameter("@Shape", SqlDbType.VarChar, 50);
                p7.Value = product.Shape;
                ParamList.Add(p7);
                SqlParameter p8 = new SqlParameter("@Appearance", SqlDbType.VarChar, 19);
                p8.Value = product.Appearance;
                ParamList.Add(p8);
                SqlParameter p9 = new SqlParameter("@Examination", SqlDbType.VarChar, 50);
                p9.Value = product.Examination;
                ParamList.Add(p9);
                SqlParameter p10 = new SqlParameter("@Volume", SqlDbType.VarChar, 4);
                p10.Value = product.Volume;
                ParamList.Add(p10);
                SqlParameter p11 = new SqlParameter("@Value", SqlDbType.VarChar, 4);
                p11.Value = product.Value;
                ParamList.Add(p11);
                SqlParameter p12 = new SqlParameter("@Quantity", SqlDbType.VarChar, 4);
                p12.Value = product.Quantity;
                ParamList.Add(p12);
                SqlParameter p13 = new SqlParameter("@NumParts", SqlDbType.VarChar, 50);
                p13.Value = product.NumParts;
                ParamList.Add(p13);
                SqlParameter p14 = new SqlParameter("@NumOperations", SqlDbType.VarChar, 19);
                p14.Value = product.NumOperations;
                ParamList.Add(p14);
                SqlParameter p15 = new SqlParameter("@Protection", SqlDbType.VarChar, 50);
                p15.Value = product.Protection;
                ParamList.Add(p15);
                res = _dataAccess.CreateUpdateDelete(sql, ParamList);
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public int DeleteProduct(int id)
        {
            int res = 0;
            try
            {
                // Se prepara la eliminación del producto indicado por su ID.
                string sql = "DELETE FROM dbo.Products WHERE id = @Id";
                List<DbParameter> ParamList = new List<DbParameter>();
                SqlParameter p1 = new SqlParameter("@Id", SqlDbType.VarChar, 4);
                p1.Value = id;
                ParamList.Add(p1);
                res = _dataAccess.CreateUpdateDelete(sql, ParamList);
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }
    }
}