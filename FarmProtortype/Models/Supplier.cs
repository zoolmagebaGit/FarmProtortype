using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmProtortype.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string FirstName { get; set; }
        public string Surname{ get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Province { get; set; }
        public string Comment { get; set; }



    }
}