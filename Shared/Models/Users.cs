
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Users
    {

        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
