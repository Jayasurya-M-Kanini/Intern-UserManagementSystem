using InternUserManagementAPI.Interfaces;
using InternUserManagementAPI.Models;

namespace InternUserManagementAPI.Services
{
    public class GeneratePasswordService : IGeneratePassword
    {
        public async Task<string?> GeneratePassword(Intern intern)
        {
            string password = String.Empty;
            password = intern.Name.Substring(0, 4);
            password += intern.DateOfBirth.Date;
            password += intern.DateOfBirth.Month;
            return password;
        }
    }
}
