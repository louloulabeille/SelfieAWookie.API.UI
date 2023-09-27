using Microsoft.AspNetCore.Http;
using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Application.DTO
{
    public class SelfieDTOAddWithPicture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //[DataType(DataType.Url)]
        //public string? PathImage { get; set; }
        public Wookie Wookie { get; set; }
        public ImageDTOBinaire? Image { get; set; }        // passé l'image en binaire
        public IFormFile File { get; set; }
    }
}
