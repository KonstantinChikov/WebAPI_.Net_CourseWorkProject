using CWProject.Data;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;

namespace CWProject.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public User GetById(int id)
        {
            return _context.Users.First(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.First(u => u.Username == username);
        }
    }
}
