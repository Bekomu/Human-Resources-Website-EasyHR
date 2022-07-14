using EasyHR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyHR.Factories
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // İzinTalepAttribute için gerekli claimler
            identity.AddClaim(new Claim("Cinsiyet", user.Cinsiyet.ToString()));
            identity.AddClaim(new Claim("YillikIzinGunSayisi", user.YillikIzinGunSayisi.ToString()));

            // AvansTalepAttribute için gerekli claimler
            identity.AddClaim(new Claim("Id", user.Id));
            identity.AddClaim(new Claim("MinAvansHakki", user.MinAvansHakki.ToString()));
            identity.AddClaim(new Claim("MaksAvansHakki", user.MaksAvansHakki.ToString()));

            return identity;
        }
    }
}
