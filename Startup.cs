using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire2.Models;

namespace Questionnaire2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<Questionnaire2.Helpers.AppSettings>(Configuration);
            // minedu Configure Session 
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // end of minedu configure session
            // start of configure mySQL 
            services.AddMvc();

            IConfigurationSection sectionQuestionsMax = Configuration.GetSection("QuestionsMax");
            IConfigurationSection sectionQuestionsTableMax = Configuration.GetSection("QuestionsTableMax");
            string[] questionsMax = sectionQuestionsMax.Get<string[]>();
            string[] questionsTableMax = sectionQuestionsTableMax.Get<string[]>();

            //   services.Add(new ServiceDescriptor(typeof(MySQLContextA), new MySQLContextA(Configuration.GetValue<string>("ConnectionString"), questionsMax))) ;
            services.Add(new ServiceDescriptor(typeof(MySQLContextA), new MySQLContextA(Configuration.GetValue<string>("ConnectionString"), questionsMax, questionsTableMax)));
            // end of configure mySQL 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

              app.UseSession();  //  minedu configure session . Must be after 'Use Routing', before 'Use EndPoints' 
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=IndexA}/{id?}");
            });
        }


        

    }
}
