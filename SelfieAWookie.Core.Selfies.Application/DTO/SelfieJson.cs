using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Application.DTO
{
    public class SelfieJson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? PathImage { get; set; }
        public WookieJson? WookieJson { get; set; }
    }
}
