using System;
using System.Collections.Generic;

namespace CPRG102.Inventory.Repository.Domain
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
