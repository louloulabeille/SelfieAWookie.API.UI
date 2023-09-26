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

        public int ImageId { get; set; }
        public Image Image { get; set; }
        //public int WookieId { get; set; }  // pas obligé de le mettre c'est un shadow clé étrangère
        public string? Description { get; set; }

        [JsonIgnore]
        public Wookie Wookie { get; set; }
        
    }
}