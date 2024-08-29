using Microsoft.AspNetCore.Mvc;

namespace MyZhiHuWeb.Controllers;

[Route("api/[controller]/[action]")]
public class ImageController : Controller
{
    // GET
    public void Upload(IList<IFormFile> UploadFiles)
    {
        Response.StatusCode = 200;
        Response.WriteAsync(UploadFiles[0].FileName + " Upload Success");
    }
}
