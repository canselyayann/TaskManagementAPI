namespace TaskManagementAPI.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }  // G�rev Id'si
        public Task Task { get; set; }  // G�revle ili�kilendirilmi� g�rev modeli
        public int UserId { get; set; }  // Atanan kullan�c� Id'si
        public User User { get; set; }  // Kullan�c�yla ili�kilendirilmi� kullan�c� modeli
    }
}
