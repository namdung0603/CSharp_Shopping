using Shopping.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Models {
    internal class Role {
        public int Id { get; set; }
        public RoleType RoleName { get; set; }
    }
}
