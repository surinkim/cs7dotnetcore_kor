using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.CS7
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        // 아래는 Categories 테이블과의 외래 키 관계를 정의한다.
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
