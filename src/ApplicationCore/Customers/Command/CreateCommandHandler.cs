using ApplicationCore.Common.Interfaces.Authentication;
using ApplicationCore.Common.Interfaces.Persistence;
using ApplicationCore.Customers.Common;
using Domain.Common.Errors;
using Domain.UserAggregate;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Enums;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Customers.Command;

public sealed class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<CustomerResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserRepository _userRepository;

    public CreateCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        ICustomerRepository customerRepository,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _customerRepository = customerRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CustomerResult>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
        {
            return Errors.User.DublicateEmail;
        }

        User user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            UserType.CustomerUser);

        if (await _userRepository.AddAsync(user) < 1)
        {
            return Errors.Customer.InvalidOperation;
        }

        Customer customer = Customer.Create(
            command.Address.PhoneNumber,
            command.Address.Street,
            command.Address.City,
            command.Address.State,
            command.Address.ZipCode,
            command.Address.Country,
            user.Id);

        if (await _customerRepository.AddAsync(customer) < 1)
        {
            return Errors.Customer.InvalidOperation;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new CustomerResult(
                customer.Id.Value.ToString(),
                user.Id.Value.ToString(),
                command.Address,
                0,
                token,
                user.CreatedAt);
    }
}
