using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using ShopTARge24.ApplicationServices.Services;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;
using ShopTARge24.KindergartenTest.Macros;

namespace ShopTARge24.KindergartenTest
{
    public abstract class TestBase
    {
        protected IServiceProvider ServiceProvider { get; private set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public virtual void SetupServices(IServiceCollection services)
        {

            services.AddSingleton<IHostEnvironment>(new HostingEnvironment
            {
                EnvironmentName = Environments.Development,
                ApplicationName = "ShopTARge24.KindergartenTest",
                ContentRootPath = AppContext.BaseDirectory
            });


            services.AddScoped<IKindergartenServices, KindergartenServices>();
            services.AddScoped<IFileServices, FileServices>();


            services.AddDbContext<ShopTARge24Context>(cfg =>
            {
                cfg.UseInMemoryDatabase("KINDERGARTEN_TEST_DB");
                cfg.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });


            RegisterMacros(services);
        }

        public T Svc<T>() => ServiceProvider.GetRequiredService<T>();

        private void RegisterMacros(IServiceCollection services)
        {
            var macroInterface = typeof(IMacros);

            var macros = macroInterface.Assembly.GetTypes()
                .Where(t => macroInterface.IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract);

            foreach (var macro in macros)
                services.AddSingleton(macro);
        }
    }
}