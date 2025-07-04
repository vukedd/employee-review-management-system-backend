using Application.Queries.Auth;
using Infrastructure.Configurations.Auth;
using Presentation.Contracts.Request.Auth;

namespace Presentation.Mappers.RefreshToken
{
    public static class TokenMapper
    {
        public static RefreshTokenQuery ToQuery(this RefreshTokenContract contract)
            => new RefreshTokenQuery(contract.Token);
    }
}
