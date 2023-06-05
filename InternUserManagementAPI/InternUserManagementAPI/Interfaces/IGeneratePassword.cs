using InternUserManagementAPI.Models;

namespace InternUserManagementAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);
    }
}
