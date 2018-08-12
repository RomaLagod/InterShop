using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL
{
    public class MyDAL : IDAL
    {
        private readonly DbContext _ctx;

        public MyDAL(DbContext ctx)
        {
            _ctx = ctx;
        }

        public Client GetClientByUP(string user, string password)
        {
            return _ctx.Set<Client>().SingleOrDefault(x => x.Username == user && x.Password == password);
        }
        public Client GetClientByUsername(string username)
        {
            return _ctx.Set<Client>().SingleOrDefault(x => x.Username == username);
        }
        public Client GetClientById(int id)
        {
            return _ctx.Set<Client>().SingleOrDefault(x => x.Id == id);
        }

        public void AddNewClient(Client client)
        {
            _ctx.Set<Client>().Add(client);
            _ctx.SaveChanges();
        }

        public void UpdateClient(Client original, Client client)
        {
            _ctx.Entry(original).CurrentValues.SetValues(client);
            _ctx.SaveChanges();
        }

        //Занесення повідомлення/скарги/пропозиції від клієнта в БД
        public void AddClientMessage(ClientMessage clientMessage)
        {
            _ctx.Set<ClientMessage>().Add(clientMessage);
            _ctx.SaveChanges();
        }

        public ICollection<Category> GetAllCategorys()
        {
            return _ctx.Set<Category>().ToArray();
        }

        public ICollection<Product> GetAllProducts()
        {
            return _ctx.Set<Product>().ToArray();
        }

        public ICollection<Product> GetProductsByCategory(int categoryId)
        {
            return _ctx.Set<Product>().Where(x => x.CategoryId == categoryId).ToArray();
        }

        public ICollection<ProductImage> GetProductImagesByProduct(int productId)
        {
            return _ctx.Set<ProductImage>().Where(x => x.ProductId == productId).ToArray();
        }

        public Manufacturer GetManufacturerById(int id)
        {
            return _ctx.Set<Manufacturer>().SingleOrDefault(x => x.Id == id);
        }

        public Order CreateNewOrder(Order order)
        {
            _ctx.Set<Order>().Add(order);
            _ctx.SaveChanges();
            return order;
        }
        public Order GetOrderById(int id)
        {
            return _ctx.Set<Order>().SingleOrDefault(x => x.Id == id);
        }

        public void UpdateOrder(Order original, Order order)
        {
            _ctx.Entry(original).CurrentValues.SetValues(order);
            _ctx.SaveChanges();
        }

        public void AddToBasket(OrderProduct orderProduct)
        {
            _ctx.Set<OrderProduct>().Add(orderProduct);
            _ctx.SaveChanges();
        }

        public decimal PurchaseAmount(int orderId)
        {
            var temp_array = _ctx.Set<OrderProduct>().Where(x => x.OrderId == orderId).ToArray();
            decimal summ = 0;
            Product product = null;
            foreach (var item in temp_array)
            {
                product = _ctx.Set<Product>().SingleOrDefault(x => x.Id == item.ProductId);
                summ += product.Price;
            }
            return summ;
        }

        public ICollection<Delivery> GetAllDelivery()
        {
            return _ctx.Set<Delivery>().ToArray();
        }

        public ICollection<Payment> GetAllPayment()
        {
            return _ctx.Set<Payment>().ToArray();
        }

        public Product GetProductById(int id)
        {
            return _ctx.Set<Product>().SingleOrDefault(x => x.Id == id);
        }

        public ICollection<OrderProduct> GetOrderProduct(int orderId)
        {
            return _ctx.Set<OrderProduct>().Where(x => x.OrderId == orderId).ToArray();
        }
    }
}
