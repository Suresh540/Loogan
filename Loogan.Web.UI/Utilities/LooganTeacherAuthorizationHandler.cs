using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static Loogan.Web.UI.Utilities.MicrosoftAuthentication;
namespace Loogan.Web.UI.Utilities;

public class LooganTeacherAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public LooganTeacherAuthorizeAttribute(string role) => Role = role;
    public string Role { get; }
    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}

public class LooganTeacherAuthorizationHandler : AuthorizationHandler<LooganTeacherAuthorizeAttribute>
{
    private const string teacher = "TEACHER";
    private const string admin = "admin";
    private readonly ILogger<LooganTeacherAuthorizationHandler> _logger;

    public LooganTeacherAuthorizationHandler(ILogger<LooganTeacherAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LooganTeacherAuthorizeAttribute requirement)
    {
        _logger.LogWarning("Evaluating authorization requirement for role = {role}", requirement.Role);
        if (DoesUserBelongsToAzureAD(context, requirement))
        {
            return Task.CompletedTask;
        }
        var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
        if (role != null)
        {
            if (role.Value.ToLower() == admin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (role.Value == requirement.Role && role.Value.ToUpper() == teacher)
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

