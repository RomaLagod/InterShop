using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ClientMessage
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
