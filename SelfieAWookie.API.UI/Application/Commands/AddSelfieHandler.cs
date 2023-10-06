using MediatR;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace SelfieAWookie.API.UI.Application.Commands
{
    public class AddSelfieHandler : IRequestHandler<AddSelfieCommand, SelfieDTOAddOne?>
    {
        private readonly ISelfieRepository _repository;

        public AddSelfieHandler(ISelfieRepository repository)
        {
            _repository = repository;
        }

        public Task<SelfieDTOAddOne?> Handle(AddSelfieCommand request, CancellationToken cancellationToken)
        {
            #region Ajout et enregistrement
            SelfieDTOAddOne retour;

            Selfie addSelfie = _repository.Add(new Selfie
            {
                Id = request.Selfie.Id,
                Title = request.Selfie.Title,
                //ImagePath = selfie.PathImage,
                Wookie = request.Selfie.Wookie,
                Image = null
            });

            _repository.SaveChanges();
            #endregion

            if (addSelfie is not null)
            {
                request.Selfie.Id = addSelfie.Id;
            }
            retour = request.Selfie;
            return Task.FromResult(retour.Id == 0 ? null : retour);
        }

    }
}
