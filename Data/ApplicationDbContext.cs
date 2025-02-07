using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;  // Gerekli model s�n�flar�n�n dahil edilmesi
using TaskModel = TaskManagementAPI.Models.Task;  // Alias tan�mlama
using System.Threading.Tasks;  // .NET'in asli Task s�n�f�

namespace TaskManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Alias kullanarak TaskModel'i kullan�yoruz
        public DbSet<TaskModel> Tasks { get; set; }  // Burada alias kullan�ld�
        public DbSet<UserTaskItem> UserTaskItems { get; set; }  // Do�ru DbSet tan�mlamas�
        public DbSet<User> Users { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoginModel>()
           .HasOne(l => l.User)  // LoginModel, User ile ili�kili
           .WithMany()  // User tablosunda birden fazla login kayd�n� kabul eder
           .HasForeignKey(l => l.UserId);  // LoginModel'deki UserId, User tablosuna yabanc� anahtar olacak

            modelBuilder.Entity<TaskModel>()
                .HasKey(t => t.Id);  // TaskModel (alias kullan�ld�)

            // UserTask ve User aras�ndaki ili�kiyi belirt
            modelBuilder.Entity<UserTaskItem>()
                .HasOne(ut => ut.User)  // UserTask'�n bir User'� olacak
                .WithMany(u => u.UserTaskItems)  // Bir User birden fazla UserTask'a sahip olabilir
                .HasForeignKey(ut => ut.UserId);  // UserTask'ta hangi s�tunun yabanc� anahtar olaca��n� belirle

            modelBuilder.Entity<UserTaskItem>()
                .HasOne(ut => ut.Task)  // UserTask'�n bir Task'� olacak
                .WithMany()  // Task modelinde birden fazla UserTask olabilir (bir Task bir�ok UserTask'a sahip olabilir)
                .HasForeignKey(ut => ut.TaskId);  // UserTask'taki TaskId s�tununu yabanc� anahtar olarak belirle
        }
    }
}
