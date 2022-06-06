using Store.BLL;
using Store.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.IOC
{
   public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region DAL

            services.AddScoped(typeof(IUnitOfWork<StoreContext>), typeof(UnitOfWork<StoreContext>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            #region BLL

            services.AddScoped<ProductCategoryBll>();
            #endregion

        }
    }
}
