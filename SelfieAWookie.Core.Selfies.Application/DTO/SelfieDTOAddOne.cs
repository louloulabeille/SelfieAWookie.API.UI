using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Application.DTO
{
    public class SelfieDTOAddOne
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Url)]
        public string? PathImage { get; set; }
        public Wookie Wookie { get; set; }
    }
}
