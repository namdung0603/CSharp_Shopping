using Shopping.Contract.Enums;
using Shopping.Infrastructure.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class User : BaseModel {
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Fullname { get; set; }

        [Required]
        public required string Password { get; set; }
        public string Avatar { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpired { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpired { get; set; }
        public AccountType AccountType { get; set; }

    }
}
