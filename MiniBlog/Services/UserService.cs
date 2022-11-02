using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStore _userStore;
        private readonly IArticleStore _articleStore;
        public UserService(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }

        public User CreateUser(User user)
        {
            if (!_userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                _userStore.Save(user);
            }
            return user;
        }

        public List<User> GetAllItems()
        {
            return _userStore.GetAll();
        }

        public User DeleteAnItem(string name)
        {
            var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                _userStore.Delete(foundUser);
                var articles = _articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => _articleStore.Delete(article));
            }

            return foundUser;
        }

        public User SerchByName(string name)
        {
            var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                _userStore.Delete(foundUser);
                var articles = _articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => _articleStore.Delete(article));
            }

            return foundUser;
        }
    }
}
