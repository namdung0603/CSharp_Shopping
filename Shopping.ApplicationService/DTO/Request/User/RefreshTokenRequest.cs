namespace Shopping.ApplicationService.DTO.Request.User {
    public class RefreshTokenRequest {
        public int UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
