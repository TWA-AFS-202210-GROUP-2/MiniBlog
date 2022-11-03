using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IUserStore
    {
        User Save(User user);
        List<User> GetAll();
        bool Delete(User user);
    }
}
