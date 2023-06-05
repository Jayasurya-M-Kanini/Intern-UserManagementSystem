using InternUserManagementAPI.Interfaces;
using InternUserManagementAPI.Intrerfaces;
using InternUserManagementAPI.Models.DTO;
using InternUserManagementAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace InternUserManagementAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly IRepo<int, Intern> _internRepo;
        private readonly IGeneratePassword _passwordService;
        private readonly ITokenGenerate _tokenService;

        public ManageUserService(IRepo<int, User> userRepo,
            IRepo<int, Intern> internRepo,
            IGeneratePassword passwordService,
            ITokenGenerate tokenService)
        {
            _userRepo = userRepo;
            _internRepo = internRepo;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public Task<UserDTO> ChangeStatus(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Register(InternDTO intern)
        {

            UserDTO user = null;
            var hmac = new HMACSHA512();
            string? generatedPassword = await _passwordService.GeneratePassword(intern);
            intern.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword ?? "1234"));
            intern.User.PasswordKey = hmac.Key;
            intern.User.Role = "Intern";
            var userResult = await _userRepo.Add(intern.User);
            var internResult = await _internRepo.Add(intern);
            if (userResult != null && internResult != null)
            {
                user = new UserDTO();
                user.UserId = internResult.Id;
                user.Role = userResult.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;

        }
    }
}
