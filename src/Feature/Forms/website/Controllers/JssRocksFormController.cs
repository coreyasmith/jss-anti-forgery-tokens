using System.Net;
using System.Web.Mvc;
using CoreySmith.Feature.Forms.Models;
using Newtonsoft.Json;
using Sitecore.LayoutService.Mvc.Security;

namespace CoreySmith.Feature.Forms.Controllers
{
  [EnableApiKeyCors]
  public class JssRocksFormController : Controller
  {
    private static string _name;

    [HttpGet]
    public ActionResult Form()
    {
      var model = new { name = _name };
      return Content(JsonConvert.SerializeObject(model), "application/json");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Form(JssRocksFormData form)
    {
      if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      _name = $"{form.Name} (MVC)";
      return new HttpStatusCodeResult(HttpStatusCode.OK);
    }
  }
}
