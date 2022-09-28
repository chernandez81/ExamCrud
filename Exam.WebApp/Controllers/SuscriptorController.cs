using Exam.Model;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

namespace Exam.WebApp.Controllers;
public class SuscriptorController : Controller
{
    private readonly Services.Services _services;

    public SuscriptorController(Services.Services services)
    {
        _services = services;
    }

    public async Task<IActionResult> Index()
    {
        await _services.GetSubscriptor();

        return View();
    }

    public async Task<JsonResult> BuscaSuscriptor (Suscriptor suscriptor)
    {
        
        var busca = new BuscaSuscriptor { NumeroDocumento = suscriptor.NumeroDocumento, TipoDocumento = Convert.ToInt32(suscriptor.TipoDocumento) };
        
        var objSuscriptor = await _services.BuscaSuscriptor(busca);
       
        return Json(objSuscriptor);
    }

    [HttpPost]
    public async Task<JsonResult> GuardaSuscriptor(Suscriptor suscriptor)
    {
        var exist = await _services.BuscaUsername(suscriptor.Username!);

        if (exist is not null)
            return Json(false);


        await _services.GuardaSuscriptor(suscriptor);

        return Json(true);
    }

    [HttpPost]
    public async Task<JsonResult> EditarSuscriptor(Suscriptor suscriptor)
    {

       await _services.EditarSuscriptor(suscriptor);

        return Json(true);
    }

    [HttpDelete]
    public JsonResult EliminarSuscriptor(Suscriptor suscriptor)
    {

        //await _services.GuardaSuscriptor(suscriptor);

        return Json("");
    }

    [HttpPost]
    public async Task<JsonResult> GuardaSuscripcion(Suscriptor suscriptor)
    {

        var suscripcion = new Suscripcion { 
            IdSuscriptor = suscriptor.IdSuscriptor,
            FechaIngreso = DateTime.Now
        };

        await _services.GuardaSuscripcion(suscripcion);
        suscriptor.Estado = "1";
        await _services.EditarSuscriptor(suscriptor);

        return Json(true);
    }
}
