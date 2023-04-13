using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandJWebApp.Models.Model
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required,StringLength(150, ErrorMessage = "150 Karakter Olabilir")]
        [DisplayName("Service Title")]
        public string Title { get; set; }
        [DisplayName("Service Explanation")]
        public string Explanition { get; set; }
        [DisplayName ("Service Image")]
        public string ImageURL { get; set; }
    }
}