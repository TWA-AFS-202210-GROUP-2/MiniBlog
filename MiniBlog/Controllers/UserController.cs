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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            if (!_userService.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                _userService.Save(user);
            }

            return new CreatedResult("/users",user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            return _userService.UpdateUser(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return _userService.Delete(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userService.GetUserByName(name);
        }
    }
}