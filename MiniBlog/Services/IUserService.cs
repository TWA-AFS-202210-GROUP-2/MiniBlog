using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User CreateUser(User user);
        public List<User> GetAllItems();
    }
}
