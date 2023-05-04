using Mc2.CrudTest.Application.Common.Helper;
using Mc2.CrudTest.Application.Customers.Command.Create;
using Mc2.CrudTest.Application.Customers.Command.Delete;
using Mc2.CrudTest.Application.Customers.Command.Update;
using Mc2.CrudTest.Application.Customers.Dto;
using Mc2.CrudTest.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers;

public class CustomersController : BaseController
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }



    /// <summary>
    ///  Get customer List
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Successfully found and returned the Customer</response>
    /// <response code="500">If an unexpected error happen</response>
    [ProducesResponseType(typeof(List<CustomerDto>), 200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
        => Ok(await _mediator.Send(new GetCustomerListQuery(), cancellationToken));



    /// <summary>
    ///  Get customer Info by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Successfully found and returned the Customer</response>
    /// <response code="404">The Customer not Found </response>
    /// <response code="500">If an unexpected error happen</response>
    [ProducesResponseType(typeof(CustomerDto), 200)]
    [ProducesResponseType(typeof(ApiMessage), 404)]
    [ProducesResponseType(500)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInfo(Guid id, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(new GetCustomerQuery { Id = id }, cancellationToken));


    /// <summary>
    ///  add new customer
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="201">add Customer successfully</response>
    /// <response code="400">The invalid parameter send or business logic not passed</response>
    /// <response code="500">If an unexpected error happen</response>
    [ProducesResponseType(typeof(CustomerDto), 201)]
    [ProducesResponseType(typeof(ApiMessage), 400)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetInfo), new { id = result.Id }, result);
    }



     /// <summary>
    ///  update customer info
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Update customer successfully</response>
    /// <response code="400">The invalid parameter send or business logic not passed</response>
    /// <response code="404">The Customer not Found </response>
    /// <response code="500">If an unexpected error happen</response>
    [ProducesResponseType(typeof(CustomerDto), 200)]
    [ProducesResponseType(typeof(ApiMessage), 400)]
    [ProducesResponseType(typeof(ApiMessage), 404)]
    [ProducesResponseType(500)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    ///  Delete Customer
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Delete customer successfully</response>
    /// <response code="404">The Customer not Found </response>
    /// <response code="500">If an unexpected error happen</response>
    [ProducesResponseType(typeof(CustomerDto), 204)]
    [ProducesResponseType(typeof(ApiMessage), 404)]
    [ProducesResponseType(500)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteCustomerCommand { Id = id }, cancellationToken);

        return NoContent();
    }
}