using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByIdAsync(int id);

        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}