using System.ComponentModel.DataAnnotations;

namespace Shopping.ApplicationService.DTO.Request.User {
    public class ChangePassword {
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }
    }
}
