using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using blobs.Services;

namespace blobs;

public class BlobController : Controller
{
    private readonly IBlobService _blobService;

    public BlobController(IBlobService blobService)
    {
        _blobService = blobService;
    }
    public IActionResult UploadBlob()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UploadBlob(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");

        var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    file.FileName);
        try
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            

            await _blobService.UploadFromFileAsync(path);
        }
        catch (Exception ex)
        {
            return Content("exception" + ex.Message + " " + ex.InnerException?.Message ?? "");
        }
        finally
        {
            //delete file from wwwroot
            System.IO.File.Delete(path);
        }
        return RedirectToAction("Index");
    }
}
