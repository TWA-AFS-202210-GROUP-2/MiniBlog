namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Services;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;
        private IArticleService _articleService;

        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService)
        {
            _articleStore = articleStore;
            _userStore = userStore;
            _articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleService.GetAllArticle();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            _articleService.CreateArticle(article);

            return new CreatedResult(string.Empty,article);
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                _articleStore.GetAll().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}