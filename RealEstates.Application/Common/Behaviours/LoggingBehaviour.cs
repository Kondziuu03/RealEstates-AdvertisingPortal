using MediatR;
using Microsoft.Extensions.Logging;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger,
        ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? String.Empty;
        var userName = _currentUserService.UserName ?? String.Empty;

        _logger.LogInformation($"Handling {requestName}");
        _logger.LogInformation("RealEstate Request: {UserId} {@UserName} {@Name} {@Request}", userId, userName, requestName, request);

        var response = await next();

        _logger.LogInformation($"Handled {typeof(TResponse).Name}");

        return response;
    }
}
