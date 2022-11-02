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
        private readonly IArticleStoreService _articleStoreService;

        public ArticleController(IArticleStoreService articleStoreService)
        {
            _articleStoreService = articleStoreService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleStoreService.List();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            return Created("articles", _articleStoreService.Create(article));
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            return _articleStoreService.GetById(id);
        }
    }
}