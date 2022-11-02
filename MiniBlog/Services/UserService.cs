using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStore userStore;
        private readonly IArticleStore articleStore;
    }
}
