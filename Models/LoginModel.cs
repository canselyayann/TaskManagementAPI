
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManagementAPI.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        // Yabanc� anahtar
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }  // Kullan�c� ile ili�kilendirme

        public string Username { get; set; }
        public string Password { get; set; }
    }
}

