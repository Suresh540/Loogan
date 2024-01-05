using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using static Loogan.Web.UI.Utilities.MicrosoftAuthentication;
namespace Loogan.Web.UI.Utilities;

public class LooganStudentAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public LooganStudentAuthorizeAttribute(string role) => Role = role.Split(',').ToList();

    public List<string> Role { get; set; }

    public string IsAzureAD { get; set; }

    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}

public class LooganStudentAuthorizationHandler : AuthorizationHandler<LooganStudentAuthorizeAttribute>
{
    private readonly ILogger<LooganStudentAuthorizationHandler> _logger;

    public LooganStudentAuthorizationHandler(ILogger<LooganStudentAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LooganStudentAuthorizeAttribute requirement)
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

public static class MicrosoftAuthentication
{
    public static bool DoesUserBelongsToAzureAD<T>(AuthorizationHandlerContext context, T requirement)
        where T : IAuthorizationRequirement
    {
        if (context?.User != null && context?.User?.Identity != null && context.User.Identity.IsAuthenticated)
        {
            foreach (var claim in context.User.Claims)
            {
                if (claim.Issuer.ToLower().Contains("https://login.microsoftonline.com"))
                {
                    context.Succeed(requirement);
                    return true;
                }
            }
        }
        return false;
    }
}
