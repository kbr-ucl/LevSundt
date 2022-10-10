using LevSundt.WebApp.UserContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Coach
{
    public class IndexModel : PageModel
    {
        private readonly WebAppUserDbContext _userDb;

        public IndexModel(WebAppUserDbContext userDb)
        {
            _userDb = userDb;
        }

        public List<CoachIndexViewModel> Users { get; set; } = new();

        public void OnGet()
        {
            var users = from user in _userDb.Users
                join claims in _userDb.UserClaims
                    on user.Id equals claims.UserId
                    into userClaimsGroup
                from claim in userClaimsGroup.DefaultIfEmpty()
                where claim.ClaimValue == null || claim.ClaimType != "Coach"
                select new CoachIndexViewModel {UserId = user.UserName};

            Users.AddRange(users);
        }
    }
}
