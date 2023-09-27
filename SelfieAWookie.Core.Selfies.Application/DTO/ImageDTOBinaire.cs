using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Application.DTO
{
    public class ImageDTOBinaire
    {
        public string Name { get; set; } = "Default-name";
        public byte[] Data { get; set; }
    }
}
