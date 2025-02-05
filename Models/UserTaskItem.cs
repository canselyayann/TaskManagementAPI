namespace TaskManagementAPI.Models
{
    public class UserTaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public int UserId { get; set; }  // UserId, User ile ili�kilendirilmi� olacak
        public User User { get; set; }    // User ile ili�ki

        public int TaskId { get; set; }  // Task'a ait bir yabanc� anahtar
        public Task Task { get; set; }   // Task ile ili�ki
    }
}

