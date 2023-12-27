using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Loogan.Web.UI.Utilities;

public class LooganAdminAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public LooganAdminAuthorizeAttribute(string role) => Role = role;
    public string Role { get; }
    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}

public class LooganAdminAuthorizationHandler : AuthorizationHandler<LooganAdminAuthorizeAttribute>
{
    private readonly ILogger<LooganAdminAuthorizationHandler> _logger;

    public LooganAdminAuthorizationHandler(ILogger<LooganAdminAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LooganAdminAuthorizeAttribute requirement)
    {
        _logger.LogWarning("Evaluating authorization requirement for role = {role}", requirement.Role);
        var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
        if (role != null)
        {
            if (role.Value == requirement.Role && role.Value.ToUpper() == "Admin")
            {
                _logger.LogInformation("Authorization requirement {Role} satisfied", requirement.Role);
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Current user's role does not satisfy the authorization requirement {role}", requirement.Role);
            }
        }
        else
        {
            _logger.LogInformation("No admin claim present");
        }

        return Task.CompletedTask;
    }
}

