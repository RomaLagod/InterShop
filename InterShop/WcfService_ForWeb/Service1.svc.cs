using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_ForWeb
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        private readonly IBLL _bll;

        public Service1()
        {
            _bll = new MyBLL(new MyDAL(new InterShopModel()));
        }

        Client IService1.GetClientByUP(string user, string password)
        {
            var client = _bll.GetClientByUP(user, password);
            return new Client
            {
                Id = client.Id,
                Username = client.Username,
                Password = client.Password,
                Salt = client.Salt,
                Status = client.Status,
                Sale = client.Sale,
                Birthday = client.Birthday,
                Email = client.Email,
                Firstname = client.Firstname,
                Lastname = client.Lastname,
                RoleId = client.RoleId
            };
        }

        bool IService1.AddNewClient(string username, string password, string salt, int status, int sale, string birthday, string email, string firstname, string lastname, int role)
        {
            BLL.Models.Client client = new BLL.Models.Client
            {
                Username = username,
                Password = password,
                Salt = salt,
                Status = status,
                Sale = sale,
                Birthday = birthday,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                RoleId = role
            };

            return _bll.AddNewClient(client);
        }

        bool IService1.UpdateClient(string id, string username, string password, string birthday, string email, string firstname, string lastname)
        {
            BLL.Models.Client client = new BLL.Models.Client
            {
                Id = Int32.Parse(id),
                Username = username,
                Password = password,
                Birthday = birthday,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
            };

            return _bll.UpdateClient(client);
        }

        bool IService1.AddClientMessage(string author, string text, string email, string phone)
        {
            BLL.Models.ClientMessage clientMessage = new BLL.Models.ClientMessage
            {
                DateTime = DateTime.Now.ToString(),
                Author = author,
                Text = text,
                Email = email,
                Phone = phone
            };

            return _bll.AddClientMessage(clientMessage);
        }

        ICollection<Category> IService1.GetAllCategorys()
        {
            List<Category> list = new List<Category>();

            foreach (var item in _bll.GetAllCategorys())
            {
                Category category = new Category
                {
                    Id = item.Id,
                    Name = item.Name,
                    Desctiption = item.Desctiption,
                    Image = item.Image
                };
                list.Add(category);
            }
            return list.ToArray();
        }

        ICollection<Product> IService1.GetAllProducts()
        {
            List<Product> list = new List<Product>();
            foreach (var item in _bll.GetAllProducts())
            {
                Product product = new Product
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    ManufacturerId = item.ManufacturerId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Keywords = item.Keywords,
                    Quantity = item.Quantity
                };
                list.Add(product);
            }
            return list.ToArray();
        }

        ICollection<Product> IService1.GetProductsByCatecory(string categoryId)
        {
            List<Product> list = new List<Product>();
            foreach (var item in _bll.GetProductsByCategory(Int32.Parse(categoryId)))
            {
                Product product = new Product
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    ManufacturerId = item.ManufacturerId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Keywords = item.Keywords,
                    Quantity = item.Quantity
                };
                list.Add(product);
            }
                return list.ToArray();
        }

        ICollection<ProductImage> IService1.GetProductImagesByProduct(string productId)
        {
            List<ProductImage> list = new List<ProductImage>();
            foreach (var item in _bll.GetProductImagesByProduct(Int32.Parse(productId)))
            {
                ProductImage productImage = new ProductImage
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Image = item.Image
                };
                list.Add(productImage);
            }
            return list.ToArray();
        }

        Manufacturer IService1.GetManufacturerById(string id)
        {
            var manufacturer = _bll.GetManufacturerById(Int32.Parse(id));
            return new Manufacturer
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Description = manufacturer.Description,
                Logo = manufacturer.Logo                
            };
        }

        Order IService1.CreateNewOrder(string clientId, string paymentId, string deliveryId, string comment)
        {
            BLL.Models.Order order = new BLL.Models.Order
            {
                ClientId = Int32.Parse(clientId),
                PeymentId = Int32.Parse(paymentId),
                DeliveryId = Int32.Parse(deliveryId),
                Comment = comment
            };

            order = _bll.CreateNewOrder(order);

            return new Order
            {
                Id = order.Id,
                ClientId = order.ClientId,
                PeymentId = order.PeymentId,
                DeliveryId = order.DeliveryId,
                Comment = order.Comment
            };
        }

        Order IService1.GetOrderById(string Id)
        {
            var order = _bll.GetOrderById(Int32.Parse(Id));
            return new Order
            {
                Id = order.Id,
                ClientId = order.ClientId,
                PeymentId = order.PeymentId,
                DeliveryId = order.DeliveryId,
                Comment = order.Comment
            };
        }

        bool IService1.UpdateOrder(string id, string clientId, string paymentId, string deliveryId, string comment)
        {
            BLL.Models.Order order = new BLL.Models.Order
            {
                Id = Int32.Parse(id),
                ClientId = Int32.Parse(clientId),
                PeymentId = Int32.Parse(paymentId),
                DeliveryId = Int32.Parse(deliveryId),
                Comment = comment
            };

            return _bll.UpdateOrder(order);
        }

        bool IService1.AddToBasket(string orderId, string productId)
        {
            BLL.Models.OrderProduct orderProduct = new BLL.Models.OrderProduct
            {
                OrderId = Int32.Parse(orderId),
                ProductId = Int32.Parse(productId)
            };

            return _bll.AddToBasket(orderProduct);
        }

        string IService1.PurchaseAmount(string id)
        {
            return _bll.PurchaseAmount(Int32.Parse(id)).ToString();
        }

        ICollection<Delivery> IService1.GetAllDelivery()
        {
            List<Delivery> list = new List<Delivery>();
            foreach (var item in _bll.GetAllDelivery())
            {
                Delivery delivery = new Delivery
                {
                    Id = item.Id,
                    Name = item.Name
                };
                list.Add(delivery);
            }
            return list.ToArray();
        }

        ICollection<Payment> IService1.GetAllPayment()
        {
            List<Payment> list = new List<Payment>();
            foreach (var item in _bll.GetAllPayment())
            {
                Payment payment = new Payment
                {
                    Id = item.Id,
                    Name = item.Name
                };
                list.Add(payment);
            }
            return list.ToArray();
        }

        ICollection<Product> IService1.GetProductsByCategoryAndSort(string categoryId, string sorttype)
        {
            List<Product> list = new List<Product>();
            foreach (var item in _bll.GetProductsByCategoryAndSort(Int32.Parse(categoryId), (ProductSort)Int32.Parse(sorttype)))
            {
                Product product = new Product
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    ManufacturerId = item.ManufacturerId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Keywords = item.Keywords,
                    Quantity = item.Quantity
                };
                list.Add(product);
            }
            return list.ToArray();
        }

        Client IService1.GetClientByUsername(string user)
        {
            var client = _bll.GetClientByUsername(user);
            return new Client
            {
                Id = client.Id,
                Username = client.Username,
                Password = client.Password,
                Salt = client.Salt,
                Status = client.Status,
                Sale = client.Sale,
                Birthday = client.Birthday,
                Email = client.Email,
                Firstname = client.Firstname,
                Lastname = client.Lastname,
                RoleId = client.RoleId
            };
        }

        Product IService1.GetProductById(string id)
        {
            var product = _bll.GetProductById(Int32.Parse(id));
            return new Product
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                ManufacturerId = product.ManufacturerId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Keywords = product.Keywords,
                Quantity = product.Quantity
            };
        }

        ICollection<OrderProduct> IService1.GetOrderProduct(string orderId)
        {
            List<OrderProduct> list = new List<OrderProduct>();
            foreach (var item in _bll.GetOrderProduct(Int32.Parse(orderId)))
            {
                OrderProduct orderProduct = new OrderProduct
                {
                    Id = item.Id,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId
                };
                list.Add(orderProduct);
            }
            return list.ToArray();
        }
    }
}
