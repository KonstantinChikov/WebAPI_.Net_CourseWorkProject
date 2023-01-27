using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface IUserService
    {
        bool ExistsByUsername(string username);

        User GetByUsername(string username);

        User GetById(int id);
    }
}
