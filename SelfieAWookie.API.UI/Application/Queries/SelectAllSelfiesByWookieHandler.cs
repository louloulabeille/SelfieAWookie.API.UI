using MediatR;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace SelfieAWookie.API.UI.Application.Queries
{
    public class SelectAllSelfiesByWookieHandler : IRequestHandler<SelectAllSelfiesByWookie,List<SelfieJson>>
    {
        private readonly ISelfieRepository _repository;

        public SelectAllSelfiesByWookieHandler(ISelfieRepository repository)
        {
            this._repository = repository;
        }

        Task<List<SelfieJson>> IRequestHandler<SelectAllSelfiesByWookie, List<SelfieJson>>.Handle(SelectAllSelfiesByWookie request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAllByWookie(request.WookieId).Select(x =>
                     new SelfieJson()
                     {
                         Id = x.Id,
                         //PathImage = x.ImagePath,
                         Title = x.Title,
                         WookieJson = x.Wookie is not null ? new WookieJson() { Id = x.Wookie.Id, Surname = x.Wookie.Surname } : null,
                     }
                    ).ToList();
            return Task.FromResult( result ); 
        }
    }
}
