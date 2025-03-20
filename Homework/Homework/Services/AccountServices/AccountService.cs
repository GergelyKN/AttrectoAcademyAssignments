using Homework.Data;
using Homework.Dtos;
using Homework.Repositories;

namespace Homework.Services.AccountServices
{
	public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}