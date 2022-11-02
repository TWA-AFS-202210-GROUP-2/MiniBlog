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

        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [HttpGet]
        public List<Article> List()
        {
            return _articleService.GetAllArticles();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {

            return new CreatedResult("/articles", _articleService.CreateArticle(article));

        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                _articleService.GetAllArticles().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}