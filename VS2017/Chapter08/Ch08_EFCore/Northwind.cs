using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    // 데이터베이스에 대한 연결을 관리한다. 
    public class Northwind : DbContext
    {
        // 이 속성들은 데이터베이스의 테이블에 매핑된다.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            // MS SQL 서버용 연결 문자열
             optionsBuilder.UseSqlServer( 
             @"Data Source=(LocalDB)\mssqlLocalDB;" + 
             "Initial Catalog=Northwind;" + 
             "Integrated Security=true;"); 

            // SQLite 연결
            //optionsBuilder.UseSqlite("Filename=../../../../Northwind.db");
        }

        protected override void OnModelCreating(
          ModelBuilder modelBuilder)
        {
            // 속성 대신 Fluent API를 사용한 예 
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(40);
        }
    }
}
