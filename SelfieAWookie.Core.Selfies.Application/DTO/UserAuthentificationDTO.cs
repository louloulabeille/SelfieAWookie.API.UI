using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Application.DTO
{
    public class UserAuthentificationDTO
    {
        public string Login {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string? Token {  get; set; }
    }
}
