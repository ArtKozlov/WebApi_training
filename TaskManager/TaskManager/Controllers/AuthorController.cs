using System;
using System.Collections;
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
        [HttpGet]
        public IEnumerable Get()
        {
            throw new NotImplementedException();
        }
    }
}
