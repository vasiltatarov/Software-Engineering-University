namespace TheRecrutmentTool.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Infrastructures;
    using Services.Candidates;
    using Services.Skills;
    using Services.Recruiters;
    using Services.Jobs;
    using Services.Interviews;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>();

            // Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheRecrutmentTool.Web", Version = "v1" });
            });

            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IRecruiterService, RecruiterService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IInterviewService, InterviewService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheRecrutmentTool.Web v1"));
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
