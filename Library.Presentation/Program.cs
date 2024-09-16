using Library.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess.EF;
using Library.DataAccess.Repositories;
using Library.Services.Interaces;
using Library.DataAccess.Interfaces;


namespace Library.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            
            

            var connectionString = builder.Configuration.GetConnectionString("Library");

            builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IRepositoryBook, BookRepository>();
            builder.Services.AddScoped<IServiceBook, BookServices>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
