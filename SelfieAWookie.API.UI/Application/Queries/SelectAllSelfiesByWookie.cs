using MediatR;
using SelfieAWookie.Core.Selfies.Application.DTO;

namespace SelfieAWookie.API.UI.Application.Queries
{
    /// <summary>
    /// Query selon id Woodid retourne la liste des Selfies
    /// </summary>
    public class SelectAllSelfiesByWookie : IRequest<List<SelfieJson>>
    {
        public int WookieId { get; set; }



    }
}
