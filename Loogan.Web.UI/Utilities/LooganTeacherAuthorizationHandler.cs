using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static Loogan.Web.UI.Utilities.MicrosoftAuthentication;
namespace Loogan.Web.UI.Utilities;

public class LooganTeacherAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public LooganTeacherAuthorizeAttribute(string role) => Role = role.Split(',').ToList();
    public List<string> Role { get; set; }

    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}

public class LooganTeacherAuthorizationHandler : AuthorizationHandler<LooganTeacherAuthorizeAttribute>
{
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
            if (requirement.Role.Any(x => x.Equals(role.Value, StringComparison.InvariantCultureIgnoreCase)))
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

