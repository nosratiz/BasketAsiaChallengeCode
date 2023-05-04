using AutoMapper;
using Mc2.CrudTest.Application.Customers.Command.Create;
using Mc2.CrudTest.Application.Customers.Command.Update;
using Mc2.CrudTest.Application.Customers.Dto;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Common.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();

        CreateMap<CreateCustomerCommand, Customer>();

        CreateMap<UpdateCustomerCommand, Customer>();
    }
}