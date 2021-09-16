using System.Threading;
using System.Threading.Tasks;
using AAS.Data;
using AAS.Data.DTOs;
using AAS.Data.Events;
using AAS.Data.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AAS.Command.Business
{
    public class CreateBusinessCommand : IRequest<BusinessDto>
    {
        public BusinessDto Business { get; set; }
    }

    public class CreateBusinessCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateBusinessCommand, BusinessDto>
    {
        public CreateBusinessCommandHandler(
            IMediator mediator, AasDbContext database, IMapper mapper, IAuthorizationService authorizationService
        ) : base(mediator, database, mapper, authorizationService)
        {
        }

        public async Task<BusinessDto> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
        {
            var businessDto = request.Business;
            bool businessAlreadyRegistered =
                await Database.Businesses.AnyAsync(e => e.BusinessName.Trim() == businessDto.BusinessName.Trim(),
                    cancellationToken);
            if (businessAlreadyRegistered)
            {
                throw new BadRequestException("Business Name already used");
            }
            
            bool userNameAlreadyRegistered =
                await Database.Businesses.AnyAsync(e => e.Username.Trim() == businessDto.Username.Trim(),
                    cancellationToken);
            if (userNameAlreadyRegistered)
            {
                throw new BadRequestException("Username already used");
            }

            var model = new Data.Models.Business()
            {
                BusinessName = businessDto.BusinessName,
                Password = businessDto.Password,
                ScheduleId = -1,
                Username = businessDto.Username,
                Field = businessDto.Field, 
                Address = businessDto.Address,
                PhoneNumber = businessDto.PhoneNumber
            };

            Database.Businesses.Add(model);
            await Database.SaveChangesAsync(cancellationToken);
            await Mediator.Publish(new BusinessCreatedDomainEvent(model), cancellationToken);
            return Mapper.Map<BusinessDto>(model);
        }

    
    }
}