using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AAS.Data;

namespace AAS.Command
{
    /// <summary>
	/// Base class of all command handlers.
	/// </summary>
    public abstract class CommandHandlerBase : HandlerBase
    {
        protected CommandHandlerBase(
            IMediator mediator,
            AasDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
            : base(mediator, database, mapper, authorizationService)
        {
        }
    }
}
