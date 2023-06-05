using InternUserManagementAPI.Models.DTO;

namespace InternUserManagementAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public string? GenerateToken(UserDTO user);
    }
}
