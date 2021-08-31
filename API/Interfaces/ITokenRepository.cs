using API.Entities;

namespace API.Interfaces
{
    public interface ITokenRepository
    {
        string CreateToken(AppUser user);
    }
}
