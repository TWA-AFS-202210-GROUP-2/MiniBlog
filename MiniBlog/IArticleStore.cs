using MiniBlog.Model;

namespace MiniBlog
{
    public interface IArticleStore
    {
        Article Save(Article article);
        List<Article> GetAll();
        bool Delete(Article article);
    }
}
