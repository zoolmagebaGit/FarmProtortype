using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FarmProtortype.Models.Extended;

namespace FarmProtortype.Models.Extended
{
    [MetadataType(typeof(SupplieeMedata))]
    public partial class suppliee
    {

    }
    public class SupplieeMedata
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please provide First Name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Surname")]
        public string Surname { get; set; }


    }
}