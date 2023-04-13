using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandJWebApp.Models.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 Karakter Olmalıdır")]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        [DisplayName ("Açıklama")]
        public string Explanation { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}