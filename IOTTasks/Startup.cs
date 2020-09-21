using AutoMapper;
using IOT.Models.DBSettings;
using IOT.Models.Model;
using IOT.Repositories.Interface;
using IOT.Repositories.Repository;
using IOT.Services.Interface;
using IOT.Services.Service;
using IOT.ViewModels.AutoMapper;
using IOTTasks.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Web.Http;

namespace IOTTasks
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
            // services.AddAutoMapper(typeof(Startup));

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }); ;

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            // Requires using Microsoft.Extensions.Options
            services.Configure<MongoDbSettings>(
                Configuration.GetSection(nameof(MongoDbSettings)));

            services.AddSingleton<IMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            // Config Dependency
            services.AddSingleton<IMongoContext, MongoContext>();

            // Repositories
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IObjectRepository, ObjectRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();

            // Services
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IObjectService, ObjectService>();
            services.AddScoped<IPlaceService, PlaceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}
