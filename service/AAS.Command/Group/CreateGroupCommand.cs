using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AAS.Data;
using AAS.Data.DTOs;
using AAS.Data.Events;
using AAS.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AAS.Command.Group
{
    public class CreateGroupCommand : IRequest<GroupDto>
    {
        public GroupDto Group { get; set; }
    }

    public class CreateGroupCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateGroupCommand, GroupDto>
    {
        public CreateGroupCommandHandler(
            IMediator mediator,
            AasDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
            : base(mediator, database, mapper, authorizationService)
        {
        }

        public async Task<GroupDto> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Group;

            bool nameAlreadyUsed = await Database.Groups.AnyAsync(e => e.Name.Trim() == dto.Name.Trim(), cancellationToken);
            if (nameAlreadyUsed)
            {
                throw new BadRequestException($"{nameof(dto.Name)} '{dto.Name}' already used.");
            }

            var model = new Data.Models.Group()
            {
                Name = dto.Name,
                IsActive = dto.IsActive
            };

            Database.Groups.Add(model);

            await Database.SaveChangesAsync(cancellationToken);

            await Mediator.Publish(new GroupCreatedDomainEvent(model), cancellationToken);

            return Mapper.Map<GroupDto>(model);
        }
    }
}
