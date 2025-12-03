using EmployeeManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EmployeeManagement.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = _httpClientFactory.CreateClient();

            //use the same API base
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponseDto>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //Save the token
            TempData["JwtToken"] = loginResponse!.Token;

            return RedirectToAction("Users");
        }

        public async Task<ActionResult> Users()
        {
            var token = TempData["JwtToken"]!.ToString();

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login");
            }

            var client = _httpClientFactory.CreateClient();
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            //set the token to the header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{baseUrl}/api/user/users");

            if (!response.IsSuccessStatusCode)
            {
                // Invalid or expired token
                return RedirectToAction("Login");
            }

            var json = await response.Content.ReadAsStringAsync();

            var users = JsonSerializer.Deserialize<List<UserAppDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //Keep the token to next request
            TempData["JwtToken"] = token;

            return View(users);
        }
    }
}
