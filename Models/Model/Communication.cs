using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandJWebApp.Models.Model
{
    [Table("Communication")]
    public class Communication
    {
        [Key]
        public int CommunicationId { get; set; }
        [StringLength(250, ErrorMessage = "250 Karakter Olmalıdır")]
        public String Adress { get; set; }
        [StringLength(20, ErrorMessage = "20 Karakter Olmalıdır")]
        public String Tel    { get; set; }
        public String Fax    { get; set; }
        public String WhatsApp { get; set; }
        public String Facebook { get; set; }
        public String Twitter { get; set; }
        public String Linkedln { get; set; }
        public String Instagram { get; set; }
    }
}