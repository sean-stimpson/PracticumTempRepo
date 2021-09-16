using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAS.Command.Business;
using AAS.Data.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AAS.API.Controllers
{
    /// <summary>
    /// Controller for Business API
    /// </summary>
    public class BusinessController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public BusinessController(IMediator mediator) : base(mediator)
        {}

        /// <summary>
        /// Create a Business
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BusinessDto>> CreateBusiness([FromBody] BusinessDto dto)
        {
            return Created("", await Mediator.Send(new CreateBusinessCommand() {Business = dto}));
        }

        /// <summary>
        /// Update a business
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<BusinessDto>> UpdateBusiness([FromBody] BusinessDto dto)
        {
            return Ok(await Mediator.Send(new UpdateBusinessCommand() {Business = dto}));
        }
        
        /// <summary>
        /// Delete a business by its Business Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessDto>> DeleteBusiness([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteBusinessCommand() {BusId = id}));
        }

        
        /// <summary>
        /// Get All Businesses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessDto>>> GetAllBusinesses()
        {
            return Ok(await Mediator.Send(new GetAllBusinesses()));
        }
        
        /// <summary>
        /// Get a business by its Business Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetBusinessById(int id)
        {
            return Ok(await Mediator.Send(new GetBusinessByBusId() { BusId = id }));
        }
    }
}
