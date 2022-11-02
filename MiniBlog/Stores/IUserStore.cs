using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IUserStore
    {
        bool Delete(User user);
        List<User> GetAll();
        void Init();
        User Save(User user);
    }
}