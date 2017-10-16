using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            // MS SQL 서버용 연결 문자열
            // 윈도우에서 VS2017을 사용하는 경우 이 코드를 사용하고
            // 아래 UseSqlite 코드를 주석 처리한다.
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\mssqllocaldb;" +
                "Initial Catalog=Northwind;" +
                "Integrated Security=true;");

            // SQLite 연결
            // macOS에서 VS Code를 사용하는 경우 이 코드를 사용한다.
            //optionsBuilder.UseSqlite(
            //"Filename=../Northwind.db");
        }
    }
}
