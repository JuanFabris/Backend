using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Account
{
    public class NewUserDto
    {
        public string UserLog { get; set; }
        public string EmailAddress { get; set; }
        public string Token { get; set; }
    }
}