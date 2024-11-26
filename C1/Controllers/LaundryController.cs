using C1.Models;
using LaverieEntities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace C1.Controllers
{
    public class LaundryController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://your-api-endpoint.com/proprietaires";

        public LaundryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Proprietaire>>(ApiBaseUrl);
                return View(response ?? new List<Proprietaire>());
            }
            catch (Exception ex)
            {
                // Log the error
                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }
    }
}
