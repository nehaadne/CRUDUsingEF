using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDUsingEF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Pid { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string Pname { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Product Price")]
        [Range(minimum: 1, maximum: 50000)]
        public double Price { get; set; }
    }
}
