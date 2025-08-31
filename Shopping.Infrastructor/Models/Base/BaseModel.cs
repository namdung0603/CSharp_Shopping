namespace Shopping.Infrastructure.Models.Base {
    public class BaseModel {
        public int Id { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
