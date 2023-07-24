using System.Net;

namespace ApplicationCore.Common.Errors;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}
