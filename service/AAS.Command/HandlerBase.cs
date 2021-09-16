using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AAS.Data;

namespace AAS.Command
{
    /// <summary>
    /// Base class of all handlers.
    /// </summary>
    public abstract class HandlerBase
    {
        protected IMediator Mediator { get; }

        protected AasDbContext Database { get; }

        protected IMapper Mapper { get; }

        protected IAuthorizationService AuthorizationService { get; }

        protected HandlerBase(
            IMediator mediator,
            AasDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
        {
            Mediator = mediator;
            Database = database;
            Mapper = mapper;
            AuthorizationService = authorizationService;
        }
    }
}
