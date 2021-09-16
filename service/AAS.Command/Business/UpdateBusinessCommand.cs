using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AAS.Data;
using AAS.Data.DTOs;
using AAS.Data.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace AAS.Command.Business
{
    public class UpdateBusinessCommand : IRequest<BusinessDto>
    {
        public BusinessDto Business { get; set; }
    }

    public class UpdateBusinessCommandHandler : CommandHandlerBase,
        IRequestHandler<UpdateBusinessCommand, BusinessDto>
    {
        public UpdateBusinessCommandHandler(IMediator mediator, AasDbContext database,
            IMapper mapper, IAuthorizationService authorizationService) : base(mediator, database, mapper,
            authorizationService)
        {

        }

        public async Task<BusinessDto> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Business;
            var model = await Database.Businesses
                .Where(x => x.BusId == dto.BusId)
                .FirstOrDefaultAsync(cancellationToken);

            if (model == null)
            {
                throw new EntityNotFoundException($"Business ID: {dto.BusId} does not exist.");
            }

            bool businessAlreadyRegistered =
                await Database.Businesses.AnyAsync(e => e.BusinessName.Trim() == dto.BusinessName.Trim(),
                    cancellationToken);
            if (businessAlreadyRegistered)
            {
                throw new BadRequestException("Business Name already used");
            }
            
            bool userNameAlreadyRegistered =
                await Database.Businesses.AnyAsync(e => e.Username.Trim() == dto.Username.Trim(),
                    cancellationToken);
            if (userNameAlreadyRegistered)
            {
                throw new BadRequestException("Username already used");
            }

            model.Username = dto.Username;
            model.Address = dto.Address;
            model.Field = dto.Field;
            model.Password = dto.Password;
            model.PhoneNumber = dto.PhoneNumber;
            model.ScheduleId = dto.ScheduleId;

            Database.Businesses.Update(model);

            await Database.SaveChangesAsync(cancellationToken);

            return Mapper.Map<BusinessDto>(model);
        }

}
}