using System;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Abstractions;
using Sitecore.Pipelines;

namespace CoreySmith.Feature.Forms.Pipelines.Initialize
{
  public class RegisterJssRocksRoutes
  {
    private readonly BaseSettings _settings;

    public RegisterJssRocksRoutes(BaseSettings settings)
    {
      _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    public void Process(PipelineArgs args)
    {
      if (_settings.GetBoolSetting(Constants.UseWebApiSetting, false)) return;
      RegisterRoutes(RouteTable.Routes);
    }

    private static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute(
        "JssRocksForm",
        "jssrocksapi/form",
        new { controller = "JssRocksForm", action = "Form" });
    }
  }
}
