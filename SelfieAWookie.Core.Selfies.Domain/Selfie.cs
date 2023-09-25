using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SelfieAWookie.Core.Selfies.Domain
{
    [Serializable]
    public class Selfie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string? ImagePath { get; set; }
        //public int WookieId { get; set; }  // pas obligé de le mettre c'est un shadow clé étrangère

        [JsonIgnore]
        public Wookie Wookie { get; set; }
        
    }
}