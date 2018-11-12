using System;
using System.Web.Http;
using Sitecore.Abstractions;
using Sitecore.Pipelines;

namespace CoreySmith.Feature.Forms.Pipelines.Initialize
{
  public class RegisterJssRocksWebApiRoutes
  {
    private readonly BaseSettings _settings;

    public RegisterJssRocksWebApiRoutes(BaseSettings settings)
    {
      _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }
    
    public void Process(PipelineArgs args)
    {
      if (!_settings.GetBoolSetting(Constants.UseWebApiSetting, false)) return;
      RegisterRoutes(GlobalConfiguration.Configuration);
    }

    private static void RegisterRoutes(HttpConfiguration config)
    {
      config.Routes.MapHttpRoute(
        "JssRocksForm",
        "jssrocksapi/form",
        new { controller = "JssRocksFormApi" });
    }
  }
}
