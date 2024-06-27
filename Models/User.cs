// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace GestaoUsuario.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

       
    }
}