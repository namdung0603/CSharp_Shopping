using Shopping.Contract.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Infrastructure.Models {
    public class Permission {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(max)")]
        public string API { get; set; }
        public RoleType Role { get; set; }
    }
}
