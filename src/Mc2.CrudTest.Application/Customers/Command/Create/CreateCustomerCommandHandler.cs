using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Application.Customers.Dto;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Helper;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Command.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCustomerCommand> _validator;

    public CreateCustomerCommandHandler(ICustomerService customerService,
        IMapper mapper,
        IValidator<CreateCustomerCommand> validator)
    {
        _customerService = customerService;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult
                .Errors
                .Select(x => new ApiMessage(x.ErrorCode ?? "400", x.ErrorMessage))
                .ToList();

            throw new BusinessException(errors);
        }

        var customer = new Customer(Guid.NewGuid(), request.FirstName, request.LastName, new Email(request.Email),
            new PhoneNumber(request.PhoneNumber),
            request.BankAccountNumber, request.DateOfBirth);


        var result = await _customerService.AddCustomerAsync(customer, cancellationToken);

        return _mapper.Map<CustomerDto>(result);
    }
}