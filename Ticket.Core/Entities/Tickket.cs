using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Core.Entities
{
    public class Tickket
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
    }
}
