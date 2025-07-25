using Backend.CORE.IRepositories;
using Backend.DATA;
using Backend.DATA.Repository;
using Backend.SERVER;
using Backend.CORE.Iservices; // ���� ����� �� �����

namespace Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>();
            builder.Services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            builder.Services.AddScoped<IActivitiesService, ActivitiesService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}