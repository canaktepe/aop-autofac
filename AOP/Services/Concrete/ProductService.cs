using System.Data.Entity;
using AOP.Aspects;
using AOP.Database;
using AOP.Database.Entities;
using AOP.Services.Abstract;
using Autofac.Extras.DynamicProxy2;

namespace AOP.Services.Concrete
{
    [Intercept(typeof(LogAspect))]
    internal class ProductService : IProductService
    {
        private readonly Context _context;

        public ProductService(Context context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            using (_context)
            {
                var addedEntity = _context.Entry<Product>(product);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
        }
    }
}