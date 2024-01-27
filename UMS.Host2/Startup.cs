using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UMS.Domain.Handler;
using UMS.Domain.Mapper;
using USM.Data.DbContexts;
using USM.Data.Repositories;

namespace UMS.Host2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            string connectionStr = Configuration.GetConnectionString("User");
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<GetUsersHandler>();
            services.AddTransient<GetUserByIdHandler>();
            services.AddTransient<LoginUserHandler>();
            services.AddTransient<CreateUserHandler>();
            services.AddTransient<UpdateUserByIdHandler>();
            services.AddTransient<DeleteUserByIdHandler>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}

