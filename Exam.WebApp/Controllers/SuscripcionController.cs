using Microsoft.AspNetCore.Mvc;

namespace Exam.WebApp.Controllers;
public class SuscripcionController : Controller
{
    private readonly Services.Services _services;

    public SuscripcionController(Services.Services services)
    {
        _services = services;
    }

    public async Task<IActionResult> Index()
    {
        await _services.GetSubscriptor();
        return View();
    }
}
