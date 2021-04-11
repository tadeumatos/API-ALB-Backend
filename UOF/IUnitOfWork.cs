using System.Threading.Tasks;
using API_ALB.Repository;

namespace API_ALB.UOF
{
    public interface IUnitOfWork
    {
      ICustomerRepository CustomerRepository{get;}
      Task Save();
    }
}