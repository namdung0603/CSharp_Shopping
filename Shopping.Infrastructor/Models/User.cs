using Shopping.Contract.Enums;
using Shopping.Infrastructure.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        [AllowNull]
        public string? Avatar { get; set; }
        [Column(TypeName = "int")]
        public RoleType Role { get; set; } = RoleType.USER;

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; } = false;

        [MaxLength(255)]
        [Required]
        public required string Address { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpired { get; set; }

        [MaxLength(512)]
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpired { get; set; }

        [Column(TypeName = "int")]
        public AccountType AccountType { get; set; }
    }
}
