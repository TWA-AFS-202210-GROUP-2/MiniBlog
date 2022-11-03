using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;
        private IUserService _userService;

        public UserController(IArticleStore articleStore, IUserStore userStore, IUserService userService)
        {
            _articleStore = articleStore;
            _userStore = userStore;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            _ = _userService.CreateUser(user);
            return new CreatedResult(string.Empty, user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _userService.GetAllItems();
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return _userService.DeleteAnItem(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userService.SerchByName(name);
        }
    }
}