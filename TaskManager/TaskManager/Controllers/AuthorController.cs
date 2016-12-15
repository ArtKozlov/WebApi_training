using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace TaskManager.Controllers
{
    public class AuthorController : ApiController
    {

        private readonly HttpClient _client;
        private HttpResponseMessage _response;
        public AuthorController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:31484");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET api/tasks
        [HttpGet]
        public IHttpActionResult Get()
        {

            _response = _client.GetAsync("/api/authorprovider").Result;
            if (_response.IsSuccessStatusCode)
            {
                return Ok(_response.Content.ReadAsStringAsync().Result);
            }
            return BadRequest();

        }
    }
}
