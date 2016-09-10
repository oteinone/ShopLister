
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopLister.App;

namespace ShopLister.Model
{
    public abstract class BaseOperations<T> : IDisposable where T : DbContext 
    {
        public T Context { get; set; }
        public IMapper Mapper { get; set; }

        public BaseOperations()
        {
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }

        public string NewId
        {
            get
            {
                return Guid.NewGuid().ToString().Replace("-", "");
            }
        }
    }

    public static class ShopListerExtensions
    {
        public static IServiceCollection AddOperations<T,I>(this IServiceCollection coll)
            where T : BaseOperations<I>, new()
            where I : DbContext
        {
            return coll.AddDbContext<I>((services, ops) => ops.UseSqlServer(services.GetRequiredService<IAppConfig>().SqlServerConnectionString))
                .AddScoped(p => new T() { Mapper = p.GetRequiredService<IMapper>(), Context = p.GetRequiredService<I>()});
        }
    }
}