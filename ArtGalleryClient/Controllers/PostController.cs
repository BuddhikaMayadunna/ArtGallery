using System.Text;
using ArtGalleryClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArtGalleryClient.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController
        public ActionResult Index()
        {
            var posts = new List<PostViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7220");
                var responseTask = client.GetAsync("/api/Post/Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PostViewModel>>();
                    readTask.Wait();

                    posts = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                return View(posts);
            }
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,UserId,Content")] PostViewModel postViewModel)
        {
            using (var client = new HttpClient())
            {
                //using JSON
                var stringContent = new StringContent(JsonConvert.SerializeObject(postViewModel), //passing material number as string
                    UnicodeEncoding.UTF8, "application/json");
                var check = stringContent.ReadAsStringAsync().GetAwaiter().GetResult();
                //This is the portion I am unsure about. I see a lot of online suggestions saying 
                //to use PostAsJsonAsync but I do not have access to the libraries. I would prefer 
                //to use PostAsync() but am unsure how to format the correct query string I believe?
                var responseTask = client.PostAsync("https://localhost:7220/api/Post/Create", stringContent);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    //Deserialize object
                    //var deserialized = JsonConvert.DeserializeObject<List<NewProjectLogViewModel>>(readTask);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
