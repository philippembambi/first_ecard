using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Application.Dtos
{
    public class LoginResponseDto
    {
        public string AccessToken {get; set;} = string.Empty;
        public string RefreshToken {get; set;} = string.Empty;
        public string FullName {get; set;} = string.Empty;
        public string Role {get; set;} = string.Empty;
    }
}