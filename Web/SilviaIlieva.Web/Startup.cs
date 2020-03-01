namespace SilviaIlieva.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Services.Data;
    using Services.Data.AutoMapper;
    using Services.Data.Contracts;
    using SilviaIlieva.Data;
    using SilviaIlieva.Data.Common;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Services.External;
    using SilviaIlieva.Services.External.Configuration;
    using SilviaIlieva.Services.External.Contracts;
    using System.Reflection;

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
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddDbContext<SilviaIlievaDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITransactionManager, TransactionManager>();
            services.AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>));
            services.AddScoped<IIllustrationService, IllustrationService>();
            services.AddScoped<IMotionService, MotionService>();
            services.AddScoped<IPaintingService, PaintingService>();
            services.AddScoped<IGraphicService, GraphicService>();
            services.AddScoped<IUtilityDataService, UtilityDataService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));

            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                                 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "administrator",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
