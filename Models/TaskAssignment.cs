namespace TaskManagementAPI.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }  // Görev Id'si
        public Task Task { get; set; }  // Görevle ilişkilendirilmiş görev modeli
        public int UserId { get; set; }  // Atanan kullanıcı Id'si
        public User User { get; set; }  // Kullanıcıyla ilişkilendirilmiş kullanıcı modeli
    }
}
