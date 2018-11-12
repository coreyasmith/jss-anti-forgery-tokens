using System;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace CoreySmith.Feature.Forms.Pipelines.Initialize
{
  public class RegisterJssRocksRoutes
  {
    public void Process(PipelineArgs args) => RegisterRoutes(RouteTable.Routes);

    private static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute(
        "JssRocksForm",
        "jssrocksapi/form",
        new { controller = "JssRocksForm", action = "Form" });
    }
  }
}
