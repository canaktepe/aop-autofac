using System.Data.Entity;
using AOP.Database;
using AOP.Database.Entities;
using AOP.Services.Abstract;

namespace AOP.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly Context _context;

        public CustomerService(Context context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            using (_context)
            {
                var addedEntity = _context.Entry<Customer>(customer);
                addedEntity.State = EntityState.Added;
            }
        }

        public void Delete(Customer customer)
        {
            using (_context)
            {
                var deletedEntity = _context.Entry<Customer>(customer);
                deletedEntity.State = EntityState.Deleted;
            }
        }
    }
}
