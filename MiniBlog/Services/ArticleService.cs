using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleStore _articleStore;
        private readonly IUserStore _userStore;

        public ArticleService(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }

        public List<Article> GetAllArticle()
        {
            return _articleStore.GetAll();
        }

    }
}
