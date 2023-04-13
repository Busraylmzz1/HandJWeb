using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandJWebApp.Models.Model
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [DisplayName("Müşteri İsim"), StringLength(30, ErrorMessage = "30 Karakter Olmalıdır")]
        public string Name { get; set; }
        
        public string LogoURL{ get; set; }
       
    }
}