using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Repository.Contexts;
using TodoList.Repository.Repositories.Abstracts;
using TodoList.Repository.Repositories.Concretes;

namespace TodoList.Repository;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITodoRepository, EfTodoRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();

        services.AddDbContext<EfCoreDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("SqlConnection")));

        return services;
    } 
}