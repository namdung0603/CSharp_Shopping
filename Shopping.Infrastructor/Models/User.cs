using Shopping.Contract.Enums;
using Shopping.Infrastructure.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Infrastructure.Models {
    public class User : BaseModel {
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Fullname { get; set; }

        [Required]
        public required string Password { get; set; }
        public string? Avatar { get; set; }
        [Column(TypeName = "int")]
        public RoleType Role { get; set; } = RoleType.USER;

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; } = false;
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpired { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpired { get; set; }

        [Column(TypeName = "int")]
        public AccountType AccountType { get; set; }
    }
}
