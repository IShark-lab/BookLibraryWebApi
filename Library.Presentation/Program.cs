using Library.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess.EF;
using Library.DataAccess.Repositories;
using Library.Services.Interaces;
using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using Library.DataAccess.Entities;
using Library.Services.Mapper;
using Library.Services.Services;


namespace Library.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            
            

            var connectionString = builder.Configuration.GetConnectionString("Library");

            builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));



            builder.Services.AddScoped<IRepositoryBorrower, BorrowerRepostiory>();
            builder.Services.AddScoped<IServiceBorrower, BorrowerServices>();
            builder.Services.AddScoped<IMapper<BorrowerDto, Borrower>, BorrowerMapper>();


            builder.Services.AddScoped<IRepositoryBook, BookRepository>();
            builder.Services.AddScoped<IServiceBook, BookServices>();
            builder.Services.AddScoped<IMapper<BookDto, Book>, BookMapper>();


            builder.Services.AddScoped<IRepositoryAuthor, AuthorRepository>();
            builder.Services.AddScoped<IServiceAuthor, AuthorServices>();
            builder.Services.AddScoped<IMapper<AuthorDto, Author>, AuthorMapper>();
            

            builder.Services.AddScoped<IRepositoryLoan, LoanRepository>();
            builder.Services.AddScoped<IServiceLoan, LoanServices>();
            builder.Services.AddScoped<IMapper<LoanDto, Loan>, LoanMapper>();



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
