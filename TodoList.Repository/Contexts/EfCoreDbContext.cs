using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Models.Models;

namespace TodoList.Repository.Contexts;

public class EfCoreDbContext : IdentityDbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var passwordHasher = new PasswordHasher<User>();

        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Alışveriş" },
            new Category { Id = 2, Name = "Temizlik" },
            new Category { Id = 3, Name = "Çalışma" },
            new Category { Id = 4, Name = "Spor" },
            new Category { Id = 5, Name = "Eğlence" }
        };

        var roles = new List<IdentityRole>
        {
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN"},
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Kullanıcı", NormalizedName = "KULLANICI"},
        };

        var users = new List<User>
        {
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet@ornek.com", UserName = "ahmet" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Ayşe", LastName = "Demir", Email = "ayse@ornek.com", UserName = "ayse" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Mehmet", LastName = "Kara", Email = "mehmet@ornek.com", UserName = "mehmet" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Fatma", LastName = "Çelik", Email = "fatma@ornek.com", UserName = "fatma" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Emre", LastName = "Koç", Email = "emre@ornek.com", UserName = "emre" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Elif", LastName = "Aydın", Email = "elif@ornek.com", UserName = "elif" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Ali", LastName = "Öztürk", Email = "ali@ornek.com", UserName = "ali" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Zeynep", LastName = "Akman", Email = "zeynep@ornek.com", UserName = "zeynep" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Murat", LastName = "Çınar", Email = "murat@ornek.com", UserName = "murat" },
            new User { Id = Guid.NewGuid().ToString(), FirstName = "Seda", LastName = "Yalçın", Email = "seda@ornek.com", UserName = "seda" },
        };

        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "sifre123");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "sifre123");
        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "sifre123");
        users[3].PasswordHash = passwordHasher.HashPassword(users[3], "sifre123");
        users[4].PasswordHash = passwordHasher.HashPassword(users[4], "sifre123");
        users[5].PasswordHash = passwordHasher.HashPassword(users[5], "sifre123");
        users[6].PasswordHash = passwordHasher.HashPassword(users[6], "sifre123");
        users[7].PasswordHash = passwordHasher.HashPassword(users[7], "sifre123");
        users[8].PasswordHash = passwordHasher.HashPassword(users[8], "sifre123");
        users[9].PasswordHash = passwordHasher.HashPassword(users[9], "sifre123");

        var todos = new List<Todo>
        {
            new Todo { Id = 1, Title = "Market alışverişi yap", Description = "Süt, ekmek ve sebzeleri al.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CategoryId = 1, UserId = users[0].Id.ToString() },
            new Todo { Id = 2, Title = "Evi temizle", Description = "Oda temizliği yap ve çöpü at.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CategoryId = 2, UserId = users[1].Id.ToString() },
            new Todo { Id = 3, Title = "Ödevimi bitir", Description = "Matematik ödevini yap.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), CategoryId = 3, UserId = users[2].Id.ToString() },
            new Todo { Id = 4, Title = "Spor salonuna git", Description = "Ağırlık antrenmanı yap.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(4), CategoryId = 4, UserId = users[3].Id.ToString() },
            new Todo { Id = 5, Title = "Film izle", Description = "Yeni çıkan bir filmi izlemek istiyorum.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), CategoryId = 5, UserId = users[4].Id.ToString() },
            new Todo { Id = 6, Title = "Kütüphaneye git", Description = "Yeni kitaplar al.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), CategoryId = 3, UserId = users[5].Id.ToString() },
            new Todo { Id = 7, Title = "Pazara git", Description = "Taze meyve ve sebze almak.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CategoryId = 1, UserId = users[6].Id.ToString() },
            new Todo { Id = 8, Title = "Arkadaşlarla buluş", Description = "Kahve içmeye gideceğim.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), CategoryId = 5, UserId = users[7].Id.ToString() },
            new Todo { Id = 9, Title = "Yeni bir tarif dene", Description = "Makarna yapmayı düşünüyorum.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(4), CategoryId = 2, UserId = users[8].Id.ToString() },
            new Todo { Id = 10, Title = "Kitap oku", Description = "Son çıkan romanı okumaya başla.", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(6), CategoryId = 3, UserId = users[9].Id.ToString() },
        };

        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Todo>().HasData(todos);
    }
}
