using Proyecto.Documents.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Documents.Contacts.DTO
{
    public class DTOContact 
    {
        public int Id_contact { get; set; }
        public string FullName_contact { get; set; }
        public string Address_contact { get; set; }
        public string Phone_contact { get; set; }
        public int Id_customer { get; set; }
    }
}