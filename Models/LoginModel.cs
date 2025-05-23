
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManagementAPI.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        // Yabancı anahtar
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }  // Kullanıcı ile ilişkilendirme

        public string Username { get; set; }
        public string Password { get; set; }
    }
}

