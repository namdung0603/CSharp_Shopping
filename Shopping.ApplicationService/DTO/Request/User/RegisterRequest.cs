namespace Shopping.ApplicationService.DTO.Request.User {
    public class RegisterRequest {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string RePassword { get; set; }
        public required string Address { get; set; }
        public string? Avatar { get; set; }
    }
}
