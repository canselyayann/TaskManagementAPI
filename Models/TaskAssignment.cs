namespace TaskManagementAPI.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }  // Görev Id'si
        public Task Task { get; set; }  // Görevle iliþkilendirilmiþ görev modeli
        public int UserId { get; set; }  // Atanan kullanýcý Id'si
        public User User { get; set; }  // Kullanýcýyla iliþkilendirilmiþ kullanýcý modeli
    }
}
