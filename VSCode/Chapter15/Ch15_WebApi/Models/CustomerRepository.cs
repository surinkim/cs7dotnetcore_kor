using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace Packt.CS7.Models
{
  public class CustomerRepository : ICustomerRepository
  {
    //스레드에 안전한 딕셔너리에 customer 정보를 캐시한다.
    //서비스를 재시작하면 customer 정보를 리셋한다.
    private static 
      ConcurrentDictionary<string, Customer> customers;

    public CustomerRepository(Northwind db)
    {
      // 데이터베이스에서 customer 정보를 읽고 CustomerID를 키로 
      // 딕셔너리에 넣은 다음, 스레드에 안전한 ConcurrentDictionary에
      // 추가한다.
      customers = new ConcurrentDictionary<string, Customer>(
        db.Customers.ToDictionary(c => c.CustomerID));
    }

    public Customer Add(Customer c)
    {
      // CustomerID를 대문자로 변환한다. 
      c.CustomerID = c.CustomerID.ToUpper();
      // 새로운 customer 정보면 추가하고, 그렇지 않으면 갱신한다.
      return customers.AddOrUpdate(c.CustomerID, c, Update);
    }

    public IEnumerable<Customer> GetAll()
    {
      return customers.Values;
    }

    public Customer Find(string id)
    {
      id = id.ToUpper();
      Customer c;
      customers.TryGetValue(id, out c);
      return c;
    }

    public bool Remove(string id)
    {
      id = id.ToUpper();
      Customer c;
      return customers.TryRemove(id, out c);
    }

    public Customer Update(string id, Customer c)
    {
      id = id.ToUpper();
      c.CustomerID = c.CustomerID.ToUpper();
      Customer old;
      if (customers.TryGetValue(id, out old))
      {
        if (customers.TryUpdate(id, c, old))
        {
          return c;
        }
      }
      return null;
    }
  }
}
