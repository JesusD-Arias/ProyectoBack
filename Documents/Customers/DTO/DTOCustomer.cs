using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Documents.Customers.DTO
{
    public class DTOCustomer
    {
        public int Id_customer { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }

    }
}