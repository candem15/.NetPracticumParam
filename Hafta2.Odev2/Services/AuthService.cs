using Hafta2.Odev2.DbOperations;
using Hafta2.Odev2.Dtos;
using Hafta2.Odev2.Exceptions;

namespace Hafta2.Odev2.Services
{
    public class AuthService
    {
        private readonly BookStoreDbContext context;
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthService> logger;

        public AuthService(BookStoreDbContext context, IConfiguration configuration, ILogger<AuthService> logger)
        {
            this.context = context;
            this.configuration = configuration;
            this.logger = logger;
        }

        public LoginUserResponseDto Login(LoginUserRequestDto requestUser)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == requestUser.Username);

            if (user == null)
                throw new WrongUsernameEnteredException();

            if (user.Password == requestUser.Password)
            {
                logger.LogInformation($"User with username: '{user.Username}' logged in!");

                return new LoginUserResponseDto()
                {
                    LoginKey = configuration["Auth:LoginKey"]
                };
            }
            else
                throw new WrongPasswordEnteredException();
        }
    }
}
