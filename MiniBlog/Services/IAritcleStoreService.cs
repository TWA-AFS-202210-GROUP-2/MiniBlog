using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IArticleStoreService
    {
        public List<Article> List();

        public Article Create(Article article);

        public Article GetById(Guid id);
    }
}
