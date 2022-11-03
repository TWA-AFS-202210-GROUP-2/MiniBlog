using MiniBlog.Model;

namespace MiniBlog
{
    public interface IUserStore
    {
        User Save(User user);
        List<User> GetAll();
        bool Delete(User user);
    }
}