using Microsoft.AspNetCore.Mvc;

namespace MyZhiHuWeb.Controllers;

[Route("api/[controller]/[action]")]
public class ImageController : Controller
{
    // GET
    public IActionResult Upload()
    {
        return Ok();
    }
}