using System.ComponentModel.DataAnnotations;

namespace Packt.CS7
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "종류")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
