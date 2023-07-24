using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Authentication;

public sealed record RegistrationRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
