using Shopping.Contract.Enums;

namespace Shopping.ApplicationService.DTO.Response {
    public class UserResponse {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public RoleType Role { get; set; }
    }
}
