using System;
using System.Linq;
using System.Transactions;
using AOP.Logging;
using AOP.Services.Abstract;
using Castle.DynamicProxy;

namespace AOP.Aspects
{
    public class LogAspect : IInterceptor
    {
        private readonly ILoggerService _loggerService;

        public LogAspect(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"{invocation.Method.Name} method invoked");

            var logParameters = invocation.Method.GetParameters().Select((t, i) => new LogParameter
            {
                Name = t.Name,
                Type = t.ParameterType.Name,
                Value = invocation.Arguments[i]
            }).ToList();

            var logDetail = new LogDetail()
            {
                FullName = invocation.Method.DeclaringType == null ? null : invocation.Method.DeclaringType.Name,
                MethodName = invocation.Method.Name,
                Parameters = logParameters
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.Suppress))
            {
                try
                {
                    int a = Convert.ToInt32("a");
                    _loggerService.Info(logDetail);
                    invocation.Proceed();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    _loggerService.Error(ex);
                    Console.WriteLine($"An error has occured: {ex.Message}");
                }
            }

            Console.WriteLine($"{invocation.Method.Name} method finished");
        }
    }
}
