using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Loogan.Web.UI.Utilities;

public class LooganStudentAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public LooganStudentAuthorizeAttribute(string role) => Role = role;
    public string Role { get; }
    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}

public class LooganStudentAuthorizationHandler : AuthorizationHandler<LooganStudentAuthorizeAttribute>
{
    private const string student = "STUDENT";
    private const string admin = "admin";
    private readonly ILogger<LooganStudentAuthorizationHandler> _logger;

    public LooganStudentAuthorizationHandler(ILogger<LooganStudentAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LooganStudentAuthorizeAttribute requirement)
    {
        _logger.LogWarning("Evaluating authorization requirement for role = {role}", requirement.Role);
        var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
        if (role != null)
        {
            if(role.Value.ToLower() == admin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (role.Value == requirement.Role && role.Value.ToUpper() == student)
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

