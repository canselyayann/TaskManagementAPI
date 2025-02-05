namespace TaskManagementAPI.Models
{
    public class Task
    {
        public int Id { get; set; }  // Birincil anahtar
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
