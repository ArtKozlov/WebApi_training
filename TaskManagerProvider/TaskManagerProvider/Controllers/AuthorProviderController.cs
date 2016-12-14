using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Entities;
using DAL.Repositories;
using DAL.Interfaces;
using TaskManagerProvider.Mapping;
using TaskManagerProvider.Models;

namespace TaskManagerProvider.Controllers
{
    public class AuthorProviderController : ApiController
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorProviderController()
        {
            _authorRepository = new AuthorRepository();
        }

        [HttpGet]
        public IEnumerable<AuthorDto> Get()
            => _authorRepository.GetAll().Select(a =>a.ToAuthorDto());
    }
}
