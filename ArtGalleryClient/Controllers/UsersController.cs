#nullable disable
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ArtGalleryClient.Models;
using Newtonsoft.Json;

namespace ArtGalleryClient.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {
        }

        // GET: Users1
        public async Task<IActionResult> Index()
        {
            return View(new List<UserRegisterViewModel>());
        }

        // GET: Users1/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: Users1/Create
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,ConfirmPassword,FirstName,LastName,EmailAddress")] UserRegisterViewModel user)
        {
             using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(user), //passing material number as string
                    UnicodeEncoding.UTF8, "application/json");
                var check = stringContent.ReadAsStringAsync().GetAwaiter().GetResult();
                var responseTask = client.PostAsync("https://localhost:7220/api/Auth/register", stringContent);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] UserLoginViewModel login)
        {
            using (var client = new HttpClient())
            {
                //using JSON
                var stringContent = new StringContent(JsonConvert.SerializeObject(login), //passing material number as string
                    UnicodeEncoding.UTF8, "application/json");
                var check = stringContent.ReadAsStringAsync().GetAwaiter().GetResult();
                var responseTask = client.PostAsync("https://localhost:7220/api/Auth/login", stringContent);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                }
            }

            return RedirectToAction("Index", "Post");
        }
    }
}
