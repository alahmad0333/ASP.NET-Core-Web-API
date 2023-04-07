using System.ComponentModel.DataAnnotations;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Auth
{
    public class AuthLoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
