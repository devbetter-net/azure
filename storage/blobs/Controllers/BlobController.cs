using Microsoft.AspNetCore.Mvc;

namespace blobs;

public class BlobController : Controller
{
    public IActionResult UploadBlob()
    {
        return View();
    }

    
}
