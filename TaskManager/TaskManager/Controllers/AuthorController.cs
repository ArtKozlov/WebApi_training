using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly TaskManagerContext _context = new TaskManagerContext();
        [HttpGet]
        public IEnumerable<Author> Get()
            => _context.Authors;
    }
}
