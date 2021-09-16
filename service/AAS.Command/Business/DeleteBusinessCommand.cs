using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AAS.Data;
using AAS.Data.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AAS.Command.Business
{
    public class DeleteBusinessCommand : IRequest<bool>
    {
        public int BusId { get; set; }
    }

    public class DeleteBusinessCommandHandler : CommandHandlerBase,
        IRequestHandler<DeleteBusinessCommand, bool>
    {
        public DeleteBusinessCommandHandler(
            IMediator mediator,
            AasDbContext context,
            IMapper mapper,
            IAuthorizationService authorizationService)
            : base(mediator, context, mapper, authorizationService)
        {
        }

        public async Task<bool> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
        {
            var id = request.BusId;
            
            var model = await Database.Businesses
                .Where(x => x.BusId == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (model == null)
            {
                throw new EntityNotFoundException($"Business with BusId {id} was not found.");
            }

            Database.Businesses.Remove(model);
            await Database.SaveChangesAsync(cancellationToken);
            Debug.Assert(Database.Businesses.Find(model.BusId) == null);
            return true;
        }
            
    }
}