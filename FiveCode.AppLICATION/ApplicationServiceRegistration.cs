using FiveCode.Application.PaymentGateways;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FiveCode.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddTransient<IExpensicePaymentGateWay, ExpensicePaymentGateWay>();
            services.AddTransient<IPremiumPaymentGateway, PremiumPaymentGateway>();
            services.AddTransient<IPaymentProcessor, PaymentProcessor>();
            return services;
        }
    }
}