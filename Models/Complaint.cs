using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set;}
        public string Reason { get; set; }
        public string Description { get; set; }
    }
}
