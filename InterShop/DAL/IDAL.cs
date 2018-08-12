using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        //Employer GetEmployerById(int id);
        //ICollection<Employer> GetAllEmploers();
        //decimal GetAvgSalary();

        Client GetClientByUP(string user, string password);
        Client GetClientByUsername(string username);
        Client GetClientById(int id);
        void AddNewClient(Client client);
        void UpdateClient(Client original, Client client);
        void AddClientMessage(ClientMessage clientMessage);
        ICollection<Category> GetAllCategorys();
        ICollection<Product> GetAllProducts();
        ICollection<Product> GetProductsByCategory(int categoryId);
        ICollection<ProductImage> GetProductImagesByProduct(int productId);
        Manufacturer GetManufacturerById(int id);
        Order CreateNewOrder(Order order);
        Order GetOrderById(int id);
        void UpdateOrder(Order original, Order order);
        void AddToBasket(OrderProduct orderProduct);
        decimal PurchaseAmount(int orderId);
        ICollection<Delivery> GetAllDelivery();
        ICollection<Payment> GetAllPayment();
        Product GetProductById(int id);
        ICollection<OrderProduct> GetOrderProduct(int orderId);
    }
}
