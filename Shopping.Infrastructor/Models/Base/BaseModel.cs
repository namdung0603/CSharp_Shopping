using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models.Base {
    public class BaseModel {
        [Key]
        public int Id { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
