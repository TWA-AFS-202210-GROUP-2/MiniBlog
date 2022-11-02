using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleStore _articleStore;
        private readonly IUserService _userService;

        public ArticleService(IArticleStore articleStore, IUserService userService) 
        {
            _articleStore = articleStore;
            _userService = userService;
        }


    }
}
