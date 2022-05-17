using System.ComponentModel.DataAnnotations;

namespace SharedClasses.Models
{
    public class UserPayload
    {

        public UserPayload(User user, string error = "")
        {
            User = user;
            Error = error;
        }

        [Required]
        public User User { get; set; }

        public string Error { get; set; } = string.Empty;
    }
}
