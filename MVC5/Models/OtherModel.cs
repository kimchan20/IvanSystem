using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class OtherModel
    {
        public class Multiplemodel
        {
            [Required(ErrorMessage="Username is required")]
            [DisplayName("Username")]
            public string username { get; set; }

            [Required(ErrorMessage="nice! ")]
            public List<String> toliststr { get; set; }
        }
    }
}