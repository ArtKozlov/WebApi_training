using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : ApiController
    {
        
        // GET api/tasks
        [HttpGet]
        public IEnumerable Get()
        {
            dynamic tasks = null;
            HttpClient client = new HttpClient();
             client.BaseAddress = new Uri("http://localhost:31484");
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/taskprovider").Result;
            if (response.IsSuccessStatusCode)
            {
                tasks = response.Content.ReadAsAsync<IEnumerable>().Result;
            }
            return tasks;

        }

        // GET api/tasks/5
        [HttpGet]
        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/tasks
        [HttpPost]
        public IHttpActionResult Post(object task)
        {
            throw new NotImplementedException();
        }

        // DELETE api/tasks/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
