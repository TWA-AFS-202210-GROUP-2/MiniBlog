using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IArticleStore articleStore;
        private IUserStore userStore;
        private IUserService userService;
        public UserController(IArticleStore articleStore, IUserStore userStore, IUserService userService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            return Created("/user", userService.Register(user));
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(userService.GetAll());
        }

        [HttpPut]
        public ActionResult<User> Update(User user)
        {
            return Ok(userService.Update(user));
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                userStore.Delete(foundUser);
                var articles = this.articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => this.articleStore.Delete(article));
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return userStore.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
        }
    }
}