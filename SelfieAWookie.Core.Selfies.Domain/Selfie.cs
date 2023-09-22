using System.ComponentModel.DataAnnotations;

namespace SelfieAWookie.Core.Selfies.Domain
{
    [Serializable]
    public class Selfie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Url]
        public string? ImagePath { get; set; }
        //public int WookieId { get; set; }  // pas obligé de le mettre c'est un shadow clé étrangère

        public Wookie? Wookie { get; set; }
        
    }
}