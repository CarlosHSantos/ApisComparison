using System.ComponentModel.DataAnnotations;

namespace SharedClasses.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Name.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Surname.")]
        [MaxLength(300, ErrorMessage = "Maximum 50 characters.")]
        public string Surname { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required E-mail.")]
        [MaxLength(300, ErrorMessage = "Maximum 100 characters.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please provide a valid email...")]
        public string Email { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required DDD.")]
        public int? DDD { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Phone number.")]
        public double? Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Password.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters.")]
        public string Password { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Role.")]
        public Role Role { get; set; }
    }
}
