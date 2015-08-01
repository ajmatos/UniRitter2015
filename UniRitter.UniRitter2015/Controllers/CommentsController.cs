﻿using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using UniRitter.UniRitter2015.Models;
using UniRitter.UniRitter2015.Services;

namespace UniRitter.UniRitter2015.Controllers
{

    public class CommentsController : BaseController<PostModel>
    {
        private readonly IRepository<CommentModel> _repo;

        public CommentsController(IRepository<CommentModel> repo)
        {
            _repo = repo;
        }
    }
}
