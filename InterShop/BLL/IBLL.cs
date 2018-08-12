using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum ProductSort
    {
        ByName,
        ByPriceAsc,
        ByPriceDesc
    };

    public interface IBLL
    {
        Client GetClientByUP(string user, string password);
        Client GetClientByUsername(string username);
        Client GetClientById(int id);
        bool AddNewClient(Client client);
        bool UpdateClient(Client client);
        bool AddClientMessage(ClientMessage clientMessage);
        ICollection<Category> GetAllCategorys();
        ICollection<Product> GetAllProducts();
        ICollection<Product> GetProductsByCategory(int categoryId);
        ICollection<ProductImage> GetProductImagesByProduct(int productId);
        Manufacturer GetManufacturerById(int id);
        Order CreateNewOrder(Order order);
        Order GetOrderById(int id);
        bool UpdateOrder(Order order);
        bool AddToBasket(OrderProduct orderProduct);
        decimal PurchaseAmount(int orderId);
        ICollection<Delivery> GetAllDelivery();
        ICollection<Payment> GetAllPayment();        
        ICollection<Product> GetProductsByCategoryAndSort(int categoryId, ProductSort sort);
        Product GetProductById(int id);
        ICollection<OrderProduct> GetOrderProduct(int orderId);
    }
}
