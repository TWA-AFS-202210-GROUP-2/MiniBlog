using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IArticleStore
    {
        public Article Save(Article article);

        public List<Article> GetAll();

        public bool Delete(Article articles);
    }
}
