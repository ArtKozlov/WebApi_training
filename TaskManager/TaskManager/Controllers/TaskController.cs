using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace TaskManager.Controllers
{
    public class TaskController : ApiController
    {
        private readonly HttpClient _client;
        private HttpResponseMessage _response;
        public TaskController()
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

            _response = _client.GetAsync("/api/taskprovider").Result;
            if (_response.IsSuccessStatusCode)
            {
                return Ok(_response.Content.ReadAsStringAsync().Result);
            }
            return BadRequest();

        }

        // GET api/tasks/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            _response = _client.GetAsync("/api/taskprovider/" + id).Result;
            if (_response.IsSuccessStatusCode)
            {
                return Ok(_response.Content.ReadAsStringAsync().Result);
            }
            return BadRequest();
        }

        // POST api/tasks
        [HttpPost]
        public IHttpActionResult Post([FromBody]object task)
        {
            _response = _client.PostAsJsonAsync("/api/taskprovider", task).Result;
            if (_response.IsSuccessStatusCode)
            {
                return Ok(_response.Content.ReadAsStringAsync().Result);
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]object task)
        {
            _response = _client.PutAsJsonAsync("/api/taskprovider", task).Result;
            if (_response.IsSuccessStatusCode)
            {
                return Ok(_response.Content.ReadAsStringAsync().Result);
            }
            return BadRequest();
        }
        // DELETE api/tasks/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _response = _client.DeleteAsync("/api/taskprovider/" + id).Result;
            if (_response.IsSuccessStatusCode)
            {
                return Ok(_response.Content.ReadAsStringAsync().Result);
            }
            return BadRequest();
        }
    }
}
