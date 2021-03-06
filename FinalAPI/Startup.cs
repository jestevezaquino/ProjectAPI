﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinalAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApiDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConexionProduccion")));
            services.AddTransient<MantenimientoService, MantenimientoService>();
            services.AddTransient<ProcesosService, ProcesosService>();
            services.AddTransient<ConsultasService, ConsultasService>();
            services.AddCors(opciones =>
            {
                opciones.AddPolicy("PermitirTodo", acceso => acceso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
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
                app.UseHsts();
            }

            app.UseCors("PermitirTodo");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
