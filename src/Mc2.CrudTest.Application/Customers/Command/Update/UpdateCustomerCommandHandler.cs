using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Application.Customers.Dto;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Command.Update;

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCustomerCommand> _validator;

    public UpdateCustomerCommandHandler(ICustomerService customerService,
        IMapper mapper,
        IValidator<UpdateCustomerCommand> validator)
    {
        _customerService = customerService;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.First().ErrorMessage);

        var customer = _mapper.Map<Customer>(request);

        var result = await _customerService.UpdateCustomerAsync(customer, cancellationToken);

        return _mapper.Map<CustomerDto>(result);
    }
}