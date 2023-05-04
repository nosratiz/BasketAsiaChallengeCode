using AutoMapper;
using Mc2.CrudTest.Application.Customers.Dto;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Queries;

public sealed class GetCustomerListQuery  : IRequest<List<CustomerDto>>
{
    
}

public sealed class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery,List<CustomerDto>>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public GetCustomerListQueryHandler(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        var customerList = await _customerService.GetCustomerListAsync(cancellationToken);

        return _mapper.Map<List<CustomerDto>>(customerList);

    }
}