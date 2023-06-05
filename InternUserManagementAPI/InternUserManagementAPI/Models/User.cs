using System.ComponentModel.DataAnnotations;

namespace InternUserManagementAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
