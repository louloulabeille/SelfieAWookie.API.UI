using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.API.UI.Models
{
    [Serializable]
    public class Error
    {
        public readonly static Error Error404 = new() { ErrorCode = 404, Message = "Lien  introuvable", };
        public readonly static Error Error500 = new() { ErrorCode = 500, Message = "Erreur interne", };

        public int ErrorCode { get; set; } = 404;
        public string Message { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

    }
}
