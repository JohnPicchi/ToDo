using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Filters;
using ToDo.Api.Services;
using ToDo.Infrastructure;
using ToDo.Infrastructure.Repositories;
using ToDo.Repositories;

namespace ToDo.Api
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
      services.AddDbContext<DatabaseContext>(opts =>
      {
        opts.UseSqlServer(Configuration.GetConnectionString("Default"));
      });
      
      services.AddControllers(opts =>
      {
        opts.Filters.Add(typeof(DatabaseContextTransactionFilter));
        opts.Filters.Add(typeof(HttpResponseExceptionFilter));
      });
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.Web", Version = "v1" });
      });

      services.AddScoped<ICreateService, CreateService>();
      services.AddScoped<IUpdateService, UpdateService>();
      services.AddScoped<IQueryService, QueryService>();
      services.AddScoped<IDeleteService, DeleteService>();
      services.AddScoped<IToDoRepository, ToDoRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.Web v1"));
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
