using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User? Save(User user);
        public List<User> GetAll();
        public User? UpdateUser(User user);
        public User? Delete(string name);
        public User? GetUserByName(string name);
    }
}