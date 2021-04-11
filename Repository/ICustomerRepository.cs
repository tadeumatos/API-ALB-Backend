using System.Collections.Generic;
using System.Threading.Tasks;
using API_ALB.Models;

namespace API_ALB.Repository
{
    public interface ICustomerRepository:IRepository<Customer>
    {
       Task<IEnumerable<Customer>> GetCustomerOlderAge(); 
       Task<IEnumerable<Customer>> GetAllCustomer();
       Task<Customer> GetCustomerById(int customerId);
       void CreateCustomer(Customer customer);
       void UpdateCustomer(Customer customer);
       void DeleteCustomer(Customer customer); 
    }
}