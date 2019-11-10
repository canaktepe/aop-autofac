using System;
using AOP.Database.Entities;
namespace AOP.Services.Abstract
{
   public interface ICustomerService
   {
       void Add(Customer customer);
       void Delete(Customer customer);
   }
}
