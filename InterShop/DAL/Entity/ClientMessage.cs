using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class ClientMessage
    {
        [Key]
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
