using System;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Product(int _Id, int _UnislnStock,
            decimal _unitPrice, int _CategoryId,
            String _Weight, String _ProductName)
        {
            this.ProductId = _Id;
            this.ProductName = _ProductName;
            this.CategoryId = _CategoryId;
            this.Weight = _Weight;
            this.UnitPrice = _unitPrice;
            this.UnislnStock = _UnislnStock;
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int UnislnStock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}