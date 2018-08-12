using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL;

namespace BLL
{
    public class MyBLL : IBLL
    {
        private readonly MyDAL _dal;

        public MyBLL(MyDAL dal)
        {
            _dal = dal;
        }

        public Client GetClientByUP(string user, string password)
        {
            DAL.Entity.Client client = _dal.GetClientByUP(user, password);
            BLL.Models.Client clientResult = null;

            clientResult = new BLL.Models.Client
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
            return clientResult;
        }

        public Client GetClientByUsername(string username)
        {
            DAL.Entity.Client client = _dal.GetClientByUsername(username);
            BLL.Models.Client clientResult = null;

            clientResult = new BLL.Models.Client
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
            return clientResult;
        }

        public Client GetClientById(int id)
        {
            DAL.Entity.Client client = _dal.GetClientById(id);
            BLL.Models.Client clientResult = null;

            clientResult = new BLL.Models.Client
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
            return clientResult;
        }

        public bool AddNewClient(Client client)
        {
            DAL.Entity.Client cl = _dal.GetClientByUsername(client.Username);

            if (cl == null)
            {
                cl = new DAL.Entity.Client
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
                _dal.AddNewClient(cl);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateClient(Client client)
        {
            DAL.Entity.Client cl_original = _dal.GetClientById(client.Id);

            if (cl_original != null)
            {
                DAL.Entity.Client cl_mod = cl_original;

                cl_mod.Username = client.Username;
                cl_mod.Password = client.Password;
                cl_mod.Birthday = client.Birthday;
                cl_mod.Email = client.Email;
                cl_mod.Firstname = client.Firstname;
                cl_mod.Lastname = client.Lastname;

                _dal.UpdateClient(cl_original,cl_mod);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddClientMessage(ClientMessage clientMessage)
        {
            DAL.Entity.ClientMessage clm = new DAL.Entity.ClientMessage
            {
                Id = clientMessage.Id,
                DateTime = clientMessage.DateTime,
                Author = clientMessage.Author,
                Text = clientMessage.Text,
                Email = clientMessage.Email,
                Phone = clientMessage.Phone
            };

            if (clm != null)
            {
                _dal.AddClientMessage(clm);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<Category> GetAllCategorys()
        {
            List<BLL.Models.Category> list = new List<BLL.Models.Category>();
            
            foreach (var item in _dal.GetAllCategorys())
            {
                var category = new BLL.Models.Category
                {
                    Id = item.Id,
                    Name = item.Name,
                    Desctiption = item.Desctiption,
                    Image = item.Image
                };
                list.Add(category);
            }
            return list;
        }

        public ICollection<Product> GetAllProducts()
        {
            List<BLL.Models.Product> list = new List<BLL.Models.Product>();

            foreach (var item in _dal.GetAllProducts())
            {
                var product = new BLL.Models.Product
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
            return list;
        }

        public ICollection<Product> GetProductsByCategory(int categoryId)
        {
            List<BLL.Models.Product> list = new List<BLL.Models.Product>();

            foreach (var item in _dal.GetProductsByCategory(categoryId))
            {
                var product = new BLL.Models.Product
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
            return list;
        }

        public ICollection<ProductImage> GetProductImagesByProduct(int productId)
        {
            List<BLL.Models.ProductImage> list = new List<BLL.Models.ProductImage>();

            foreach (var item in _dal.GetProductImagesByProduct(productId))
            {
                var image = new BLL.Models.ProductImage
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Image = item.Image
                };
                list.Add(image);
            }
            return list;
        }

        public Manufacturer GetManufacturerById(int id)
        {
            DAL.Entity.Manufacturer manufacturer = _dal.GetManufacturerById(id);
            BLL.Models.Manufacturer manufacturerResult = null;

            manufacturerResult = new BLL.Models.Manufacturer
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Description = manufacturer.Description,
                Logo = manufacturer.Logo
            };
            return manufacturerResult;
        }

        public Order CreateNewOrder(Order order)
        {
            DAL.Entity.Order ord = new DAL.Entity.Order
            {
                Id = order.Id,
                ClientId = order.ClientId,
                PeymentId = order.PeymentId,
                DeliveryId = order.DeliveryId,
                Comment = order.Comment                
            };
            if (ord != null)
            {
                ord = _dal.CreateNewOrder(ord);
                BLL.Models.Order ord_new = new BLL.Models.Order
                {
                    Id = ord.Id,
                    ClientId = ord.ClientId,
                    PeymentId = ord.PeymentId,
                    DeliveryId = ord.DeliveryId,
                    Comment = ord.Comment
                };

                return ord_new;
            }            
            else
            {
                return null;
            }
        }
        public Order GetOrderById(int id)
        {
            DAL.Entity.Order order = _dal.GetOrderById(id);
            BLL.Models.Order orderResult = null;

            orderResult = new BLL.Models.Order
            {
                Id = order.Id,
                ClientId = order.ClientId,
                PeymentId = order.PeymentId,
                DeliveryId = order.DeliveryId,
                Comment = order.Comment
            };
            return orderResult;
        }

        public bool UpdateOrder(Order order)
        {
            DAL.Entity.Order ord_original = _dal.GetOrderById(order.Id);

            if (ord_original != null)
            {
                DAL.Entity.Order ord_mod = ord_original;

                ord_mod.ClientId = order.ClientId;
                ord_mod.PeymentId = order.PeymentId;
                ord_mod.DeliveryId = order.DeliveryId;
                ord_mod.Comment = order.Comment;

                _dal.UpdateOrder(ord_original, ord_mod);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddToBasket(OrderProduct orderProduct)
        {
            DAL.Entity.OrderProduct ord = new DAL.Entity.OrderProduct
            {
                Id = orderProduct.Id,
                OrderId = orderProduct.OrderId,
                ProductId = orderProduct.ProductId
            };
            if (ord != null)
            {
                _dal.AddToBasket(ord);
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal PurchaseAmount(int orderId)
        {
            return _dal.PurchaseAmount(orderId);
        }

        public ICollection<Delivery> GetAllDelivery()
        {
            List<BLL.Models.Delivery> list = new List<BLL.Models.Delivery>();

            foreach (var item in _dal.GetAllDelivery())
            {
                var delivery = new BLL.Models.Delivery
                {
                    Id = item.Id,
                    Name = item.Name
                };
                list.Add(delivery);
            }
            return list;
        }

        public ICollection<Payment> GetAllPayment()
        {
            List<BLL.Models.Payment> list = new List<BLL.Models.Payment>();

            foreach (var item in _dal.GetAllPayment())
            {
                var payment = new BLL.Models.Payment
                {
                    Id = item.Id,
                    Name = item.Name
                };
                list.Add(payment);
            }
            return list;
        }

        public ICollection<Product> GetProductsByCategoryAndSort(int categoryId, ProductSort sort)
        {
            List<Product> list = GetProductsByCategory(categoryId).ToList();

            switch (sort)
            {
                case ProductSort.ByName:
                    list =  list.OrderBy(x => x.Name).ToList();
                    break;
                case ProductSort.ByPriceAsc:
                    list = list.OrderBy(x => x.Price).ToList();
                    break;
                case ProductSort.ByPriceDesc:
                    list = list.OrderByDescending(x => x.Price).ToList();
                    break;                 
            }

            return list;
        }

        public Product GetProductById(int id)
        {
            DAL.Entity.Product product = _dal.GetProductById(id);
            BLL.Models.Product productResult = null;

            productResult = new BLL.Models.Product
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                ManufacturerId = product.ManufacturerId,
                Name = product.Name,
                Description =product.Description,
                Price = product.Price,
                Keywords = product.Keywords,
                Quantity = product.Quantity
            };
            return productResult;
        }

        public ICollection<OrderProduct> GetOrderProduct(int orderId)
        {
            List<BLL.Models.OrderProduct> list = new List<BLL.Models.OrderProduct>();

            foreach (var item in _dal.GetOrderProduct(orderId))
            {
                var orderproduct = new BLL.Models.OrderProduct
                {
                    Id = item.Id,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId
                };
                list.Add(orderproduct);
            }
            return list;
        }
    }
}
