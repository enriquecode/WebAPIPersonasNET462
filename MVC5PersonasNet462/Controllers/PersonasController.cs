using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5PersonasNet462.Models;
using System.Net.Http;
using Newtonsoft.Json;
//using System.Web.Http;

namespace MVC5PersonasNet462.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            IEnumerable<Persona> personas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3136/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Personas");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Persona>>();
                    readTask.Wait();

                    personas = readTask.Result;


                    //HttpResponseMessage response = await client.GetAsync(subUrl);
                    //response.EnsureSuccessStatusCode();

                    //var responseAsString = await result.Content.ReadAsStringAsync();

                    //students = JsonConvert.DeserializeObject<List<Persona>>(responseAsString);


                }
                else //web api sent error response 
                {
                    //log response status here..

                    personas = Enumerable.Empty<Persona>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(personas);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Persona persona)
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:64189/api/student");
                //client.BaseAddress = new Uri("http://localhost:3136/api/");
                client.BaseAddress = new Uri("http://localhost:3136/api/Personas/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Persona>("", persona);
                
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(persona);
        }

    }
}