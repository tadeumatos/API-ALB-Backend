using System.Threading.Tasks;
using API_ALB.Context;
using API_ALB.Repository;

namespace API_ALB.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private CustomerRepository customerRepository;
        public AppDbContext _context;

       public UnitOfWork(AppDbContext context)
       {
           _context=context;
           
       }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                return customerRepository = customerRepository ?? new CustomerRepository(_context);
            }
        }
        public async Task Save()
        {
            _context.Database.BeginTransaction();
            await _context.SaveChangesAsync();
            _context.Database.CommitTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}