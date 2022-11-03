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
        private IUserStoreService _userStoreService;
        public UserController(IUserStoreService userStoreService)
        {
            _userStoreService = userStoreService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            return Created("/users", _userStoreService.Register(user));
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _userStoreService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            return _userStoreService.Update(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return _userStoreService.Delete(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userStoreService.GetByName(name);
        }
    }
}