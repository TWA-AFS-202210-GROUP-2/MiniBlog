using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User CreateUser(User user);

        public List<User> GetAllItems();

        public User DeleteAnItem(string name);

        public User SerchByName(string name);
    }
}
