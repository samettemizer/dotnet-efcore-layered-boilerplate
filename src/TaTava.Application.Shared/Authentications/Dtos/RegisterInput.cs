using TaTava.Application.Shared.Dtos;

namespace TaTava.Authentications.Users.Dtos
{
    public class RegisterInput : EntityDto
    {
        //User Account Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //User Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}