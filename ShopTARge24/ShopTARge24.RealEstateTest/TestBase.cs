using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.ApplicationServices.Services;
using ShopTARge24.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ShopTARge24.RealEstateTest
{
    public abstract class TestBase
    {
        protected IServiceProvider ServiceProvider { get; set; }
        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public virtual void SetupServices(IServiceCollection services) 
        {
            services.AddScoped<IRealEstateServices, RealEstateServices>();

            services.AddDbContext<ShopTARge24Context>(x =>
            {
                x.UseInMemoryDatabase("Test");
                x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            RegisterMacros(services);
        }

        public void Dispose() 
        { 
            
        }

        private void RegisterMacros(IServiceCollection services) 
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(t => macroBaseType.IsAssignableFrom(t)
                && !t.IsInterface && !t.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}
