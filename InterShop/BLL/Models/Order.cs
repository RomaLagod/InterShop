using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PeymentId { get; set; }
        public int DeliveryId { get; set; }
        public string Comment { get; set; }
    }
}
