using ExampleJwtApp.Front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExampleJwtApp.Front.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return client;
        }
        public async Task<IActionResult> List()
        {
            var client = this.CreateClient();

            var response = await client.GetAsync("http://localhost:5138/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<CategoryListResponseModel>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Remove(int id)
        {
            var client = this.CreateClient();
            await client.DeleteAsync($"http://localhost:5138/api/Categories/{id}");
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View(new CategoryCreateRequestModel());
        }
        [HttpPost]
        public IActionResult Create(CategoryCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }

    }
}

