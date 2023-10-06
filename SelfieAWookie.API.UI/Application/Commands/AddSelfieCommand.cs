using MediatR;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.UI.Application.Commands
{
    public class AddSelfieCommand : IRequest<SelfieDTOAddOne>
    {
        public SelfieDTOAddOne Selfie {  get; set; }
    }
}
