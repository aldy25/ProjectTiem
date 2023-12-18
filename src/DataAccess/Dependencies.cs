using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Dependencies
    {
        public static void AddDataAccessServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoenixContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("PhoenixConnection"))
                    );
        }
    }
}
