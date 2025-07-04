using System.Security.Claims;

namespace ExampleMvcProject.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            var idClaim = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var emailClaim = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

            var id = idClaim ?? "NoId";
            var email = emailClaim ?? "NoEmail";

            return new CurrentUser(id, email);
        }
    }
}
