using TaTava.Application.Shared.Dtos;

namespace TaTava.Authentications.Users.Dtos
{
    public class LoginInput : EntityDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}