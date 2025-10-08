using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationService.DTO.Request {
    public class UserRequestSignin {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string RePassword { get; set; }
        public required string Address { get; set; }
        public string Avatar { get; set; }
    }
}
