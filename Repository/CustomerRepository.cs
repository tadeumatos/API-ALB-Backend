using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ALB.Context;
using API_ALB.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ALB.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context):base(context){}
        public async Task<IEnumerable<Customer>> GetCustomerOlderAge()
        {
            return await GetAll().OrderBy(c=>c.Age).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await GetAll().ToListAsync();
        }
       
        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await FindByCondition(c => c.CustomerId.Equals(customerId))
            .FirstOrDefaultAsync();   
        } 

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }

    }
}