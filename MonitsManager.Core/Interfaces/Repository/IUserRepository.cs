using MonitsManager.Domain;

namespace MonitsManager.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        bool Exists(User user);
        bool Exists(string email);
    }
}
