using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace demoSqlSaveJson.Infraestructure.NativeInjector
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services) => services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
