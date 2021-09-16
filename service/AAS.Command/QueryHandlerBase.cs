﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AAS.Data;

namespace AAS.Command
{
    /// <summary>
	/// Base class of all query handlers.
	/// </summary>
    public abstract class QueryHandlerBase : HandlerBase
    {
        protected QueryHandlerBase(
            IMediator mediator,
            AasDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
            : base(mediator, database, mapper, authorizationService)
        {
            // queries do not make changes to the database so we do not need ChangeTracker
            database.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }
    }
}
