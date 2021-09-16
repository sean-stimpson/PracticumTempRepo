using System.Collections;
using System.Collections.Generic;
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

namespace AAS.Command.Business
{
    public class GetAllBusinesses : IRequest<IEnumerable<BusinessDto>>
    {
    }

    public class GetBusinessByBusId : IRequest<BusinessDto>
    {
        public int BusId { get; set; }
    }

    public class GetBusinessesHandler : QueryHandlerBase, IRequestHandler<GetAllBusinesses, IEnumerable<BusinessDto>>,
        IRequestHandler<GetBusinessByBusId, BusinessDto>
    {
        public GetBusinessesHandler(
            IMediator mediator, AasDbContext database,
            IMapper mapper, IAuthorizationService authorizationService) : base(mediator, database, mapper,
            authorizationService
        )
        {
        }

        public async Task<IEnumerable<BusinessDto>> Handle(GetAllBusinesses request,
            CancellationToken cancellationToken)
        {
            return await Database.Businesses.Select(x => Mapper.Map<BusinessDto>(x)).ToListAsync(cancellationToken);
        }

        public async Task<BusinessDto> Handle(GetBusinessByBusId request, CancellationToken cancellationToken)
        {
            if (request.BusId <= 0)
            {
                throw new BadRequestException($"The business id provided, {request.BusId}, was either null or invalid");
            }

            var businessFound = await Database.Businesses.FindAsync(new object[] {request.BusId}, cancellationToken);
            if (businessFound == null)
            {
                throw new EntityNotFoundException($"Business with business id : {request.BusId}, was not found");
            }

            return Mapper.Map<BusinessDto>(businessFound);
        }
}
}