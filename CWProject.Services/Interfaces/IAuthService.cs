using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface IAuthService
    {
        string CreateJwt(User user);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
