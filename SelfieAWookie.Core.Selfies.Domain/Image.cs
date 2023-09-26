using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Domain
{
    public class Image
    {
        public int Id { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; } = string.Empty;

        public ICollection<Selfie> Selfies { get; set; } = new List<Selfie>();
    }
}
