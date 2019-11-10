using System;
using AOP.Database.Entities;
using AOP.Services.Abstract;
using Autofac;

namespace AOP
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var container = DependencyInjection.Register();
          
            var productService = container.Resolve<IProductService>();
            var customerService = container.Resolve<ICustomerService>();

            var product = new Product
            {
                Name = "New Product_" + new Random().Next()
            };

            productService.Add(product);
            Console.ReadKey();
        }
    }
}
