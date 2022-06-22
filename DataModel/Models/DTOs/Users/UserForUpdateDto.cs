using System.ComponentModel.DataAnnotations;
namespace DataModel.Models.DTOs.User
{
    public class UserForUpdateDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
