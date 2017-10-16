using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.CS7
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        // 연관된 행(row)을 관리하기 위해 탐색 속성을 정의한다.
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }
}
