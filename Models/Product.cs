using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMvc.Models
{
    /// <summary>
    /// Classe <c>Product</c>. Modela la información de un producto.
    /// </summary>
    public class Product : EntityBase
    {
        public long Id { get; set; }
        public long GroupCode { get; set; }
        public string CreatedOn { get; set; }
        public string DeletedOn { get; set; }
        public string Material { get; set; }
        public string Weight { get; set; }
        public string Shape { get; set; }
        public string Appearance { get; set; }
        public string Examination { get; set; }
        public int Volume { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public string NumParts { get; set; }
        public string NumOperations { get; set; }
        public string Protection { get; set; }
    }
}