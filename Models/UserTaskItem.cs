namespace TaskManagementAPI.Models
{
    public class UserTaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public int UserId { get; set; }  // UserId, User ile iliþkilendirilmiþ olacak
        public User User { get; set; }    // User ile iliþki

        public int TaskId { get; set; }  // Task'a ait bir yabancý anahtar
        public Task Task { get; set; }   // Task ile iliþki
    }
}

