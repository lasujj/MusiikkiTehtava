using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusiikkiTehtava.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;



namespace MusiikkiTehtava
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {


            //Vaihda "(localdb)\mssqllocaldb" oman sql palvelimen osoitteeksi
            var connection = @"Server=(localdb)\mssqllocaldb;Database=MusiikkiDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<MusiikkiContext>(options => options.UseSqlServer(connection));
            services.AddMvc()
            .AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Musiikkirajapinta", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Musiikkirajapinta");
            });
            app.UseMvc();
            
        }
    }
}