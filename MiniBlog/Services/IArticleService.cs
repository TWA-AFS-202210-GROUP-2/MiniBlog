using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public interface IArticleService
    {
        public List<Article> GetAllArticle();

        public Article CreateArticle(Article article);

        Article SearchById(Guid guid);
    }
}
