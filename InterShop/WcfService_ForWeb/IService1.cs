using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_ForWeb
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetClientByUP?userName={user}&userPassword={password}")]
        Client GetClientByUP(string user, string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetClientByUsername?userName={user}")]
        Client GetClientByUsername(string user);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/AddNewClient?username={username}&password={password}&salt={salt}&status={status}&sale={sale}&birthday={birthday}&email={email}&firstname={firstname}&lastname={lastname}&role={role}")]
        bool AddNewClient(string username, string password, string salt, int status, int sale, string birthday, string email, string firstname, string lastname, int role);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/UpdateClient?id={id}&username={username}&password={password}&birthday={birthday}&email={email}&firstname={firstname}&lastname={lastname}")]
        bool UpdateClient(string id, string username, string password, string birthday, string email, string firstname, string lastname);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/AddClientMessage?author={author}&text={text}&email={email}&phone={phone}")]
        bool AddClientMessage(string author, string text, string email, string phone);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetAllCategorys")]
        ICollection<Category> GetAllCategorys();

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetAllProducts")]
        ICollection<Product> GetAllProducts();

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetProductsByCatecory?categoryId={categoryId}")]
        ICollection<Product> GetProductsByCatecory(string categoryId);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetProductImagesByProduct?productId={productId}")]
        ICollection<ProductImage> GetProductImagesByProduct(string productId);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetManufacturerById?id={id}")]
        Manufacturer GetManufacturerById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/CreateNewOrder?clientId={clientId}&paymentId={paymentId}&deliveryId={deliveryId}&comment={comment}")]
        Order CreateNewOrder(string clientId, string paymentId, string deliveryId, string comment);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetOrderById?Id={Id}")]
        Order GetOrderById(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/UpdateOrder?id={id}&clientId={clientId}&paymentId={paymentId}&deliveryId={deliveryId}&comment={comment}")]
        bool UpdateOrder(string id, string clientId, string paymentId, string deliveryId, string comment);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/AddToBasket?orderId={orderId}&productId={productId}")]
        bool AddToBasket(string orderId, string productId);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/PurchaseAmount?id={id}")]
        string PurchaseAmount(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetAllDelivery")]
        ICollection<Delivery> GetAllDelivery();

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetAllPayment")]
        ICollection<Payment> GetAllPayment();

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetProductsByCategoryAndSort?categoryId={categoryId}&sorttype={sortType}")]
        ICollection<Product> GetProductsByCategoryAndSort(string categoryId, string sorttype);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetProductById?id={id}")]
        Product GetProductById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/GetOrderProduct?orderId={orderId}")]
        ICollection<OrderProduct> GetOrderProduct(string orderId);
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    //1-----------------------------------------------------------------
    [DataContract]
    public class Role
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    //2-----------------------------------------------------------------
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int Sale { get; set; }
        [DataMember]
        public string Birthday { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public int RoleId { get; set; }
    }

    //3-----------------------------------------------------------------
    [DataContract]
    public class Payment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    //4-----------------------------------------------------------------
    [DataContract]
    public class Delivery
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    //5-----------------------------------------------------------------
    [DataContract]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Desctiption { get; set; }
        [DataMember]
        public string Image { get; set; }
    }

    //6-----------------------------------------------------------------
    [DataContract]
    public class Manufacturer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Logo { get; set; }
    }

    //7-----------------------------------------------------------------
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int ManufacturerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Decimal Price { get; set; }
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }

    //8-----------------------------------------------------------------
    [DataContract]
    public class ProductImage
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Image { get; set; }
    }

    //9-----------------------------------------------------------------
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PeymentId { get; set; }
        [DataMember]
        public int DeliveryId { get; set; }
        [DataMember]
        public string Comment { get; set; }
    }

    //10-----------------------------------------------------------------
    [DataContract]
    public class OrderProduct
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
    }

    //11-----------------------------------------------------------------
    [DataContract]
    public class ClientMessage
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DateTime { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}