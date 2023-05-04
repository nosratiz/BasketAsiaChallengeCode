using AutoMapper;
using Mc2.CrudTest.Application.Customers.Dto;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Queries;

public sealed class GetCustomerQuery : IRequest<CustomerDto>
{
    public Guid Id { get; set; }
}

public sealed class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery,CustomerDto>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer= await _customerService.GetCustomerAsync(request.Id, cancellationToken);

        return _mapper.Map<CustomerDto>(customer);
    }
}