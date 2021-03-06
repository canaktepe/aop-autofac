﻿using AOP.Aspects;
using AOP.Database;
using AOP.Logging.Log4Net;
using AOP.Logging.Log4Net.Logger;
using AOP.Services.Abstract;
using AOP.Services.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace AOP
{
    public static class DependencyInjection
    {
        public static IContainer Register()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<Context>().AsSelf();
            containerBuilder.Register(x => new DatabaseLogger()).As<LoggerService>();

            containerBuilder.RegisterType<ProductService>().As<IProductService>().EnableInterfaceInterceptors();
            containerBuilder.RegisterType<CustomerService>().As<ICustomerService>().EnableInterfaceInterceptors();

            containerBuilder.RegisterType<LogAspect>();

            return containerBuilder.Build();
        }
    }
}