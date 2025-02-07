using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;  // Gerekli model sýnýflarýnýn dahil edilmesi
using TaskModel = TaskManagementAPI.Models.Task;  // Alias tanýmlama
using System.Threading.Tasks;  // .NET'in asli Task sýnýfý

namespace TaskManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Alias kullanarak TaskModel'i kullanýyoruz
        public DbSet<TaskModel> Tasks { get; set; }  // Burada alias kullanýldý
        public DbSet<UserTaskItem> UserTaskItems { get; set; }  // Doðru DbSet tanýmlamasý
        public DbSet<User> Users { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoginModel>()
           .HasOne(l => l.User)  // LoginModel, User ile iliþkili
           .WithMany()  // User tablosunda birden fazla login kaydýný kabul eder
           .HasForeignKey(l => l.UserId);  // LoginModel'deki UserId, User tablosuna yabancý anahtar olacak

            modelBuilder.Entity<TaskModel>()
                .HasKey(t => t.Id);  // TaskModel (alias kullanýldý)

            // UserTask ve User arasýndaki iliþkiyi belirt
            modelBuilder.Entity<UserTaskItem>()
                .HasOne(ut => ut.User)  // UserTask'ýn bir User'ý olacak
                .WithMany(u => u.UserTaskItems)  // Bir User birden fazla UserTask'a sahip olabilir
                .HasForeignKey(ut => ut.UserId);  // UserTask'ta hangi sütunun yabancý anahtar olacaðýný belirle

            modelBuilder.Entity<UserTaskItem>()
                .HasOne(ut => ut.Task)  // UserTask'ýn bir Task'ý olacak
                .WithMany()  // Task modelinde birden fazla UserTask olabilir (bir Task birçok UserTask'a sahip olabilir)
                .HasForeignKey(ut => ut.TaskId);  // UserTask'taki TaskId sütununu yabancý anahtar olarak belirle
        }
    }
}
