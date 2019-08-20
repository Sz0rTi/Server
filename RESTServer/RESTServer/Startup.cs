using AutoMapper;
using DAO.Context;
using Managment;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RESTServer
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
            //services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("ToDoList"));
            
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            /*
             * DO TESTÓW BEZ UŻYCIA ZEWNĘTRZNEJ BAZY DANYCH
             * services.AddDbContext<MagazineContext>(opt => opt.UseInMemoryDatabase("MagazineList"));*/
            services.AddDbContext<MagazineContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MagazineContext")));//z użyciem zewnętrznej (lokalnej) bazy danych
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MagazineContext>();
            services.AddManagment();
            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                //obj\Debug\netcoreapp2.2\PollsManagment.xml
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Ankieter API V1",
                    Description = "V1",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Strona główna",
                        Email = "Zakładka: kontakt",
                        Url = ""
                    }

                });
                c.DescribeAllEnumsAsStrings();
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //c.IncludeXmlComments(Path.Combine(basePath, "PollsManagment.xml"));
                //c.IncludeXmlComments(Path.Combine(basePath, "Polls.xml"));
                c.CustomSchemaIds(i => i.FullName);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = "api/swagger";

            });

        }
    }
}
