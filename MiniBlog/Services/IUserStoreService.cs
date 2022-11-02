using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserStoreService
    {
        public User Register(User user);
        public List<User> GetAll();
        public User Update(User user);
        public User Delete(string name);
        public User GetByName(string name);
    }
}
