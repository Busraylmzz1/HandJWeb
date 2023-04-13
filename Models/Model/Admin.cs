using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HandJWebApp.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Adminid { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 Karakter Olmalıdır")]
        public string Eposta { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 Karakter Olmalıdır")]
        public string Password { get; set; }
        public string Authority { get; set; }


    }
}