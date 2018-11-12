using System.Web.Http;
using CoreySmith.Feature.Forms.Models;
using Sitecore.Web.Http.Filters;

namespace CoreySmith.Feature.Forms.Controllers
{
  public class JssRocksFormApiController : ApiController
  {
    private static string _name;

    [HttpGet]
    public IHttpActionResult Get()
    {
      var model = new { name = _name };
      return Json(model);
    }

    [HttpPost]
    [ValidateHttpAntiForgeryToken]
    public IHttpActionResult Post(JssRocksFormData form)
    {
      if (!ModelState.IsValid) return BadRequest();

      _name = $"{form.Name} (Web API)";
      return Ok();
    }
  }
}
