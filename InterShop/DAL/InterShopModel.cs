using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InterShopModel : DbContext
    {
        public InterShopModel() : base("MyConStringAzure")
        {

        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Delivery> Deliveryes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<ClientMessage> ClientMessages { get; set; }
    }
}
