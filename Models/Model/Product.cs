using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace HandJWebApp.Models.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [DisplayName("Ürünler Başlık"), StringLength(30, ErrorMessage = "30 Karakter Olmalıdır")]
        public string Title { get; set; }
        [DisplayName("Ürünler Açıklama"), StringLength(150, ErrorMessage = "150 Karakter Olmalıdır")]
        public string Contents { get; set; }
        [DisplayName("Slider Resim"), StringLength(250)]
        public string ImageURL { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime DataChanged { get; set; }
    }
}