using System.Web.Http.Cors;
using CoreySmith.Feature.Forms.Controllers;
using CoreySmith.Feature.Forms.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace CoreySmith.Feature.Forms
{
  public class FormsConfigurator : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<ICorsPolicyProviderFactory, SupportsCredentialsCorsPolicyProviderFactory>();
      serviceCollection.AddTransient<JssRocksFormApiController>();
      serviceCollection.AddTransient<JssRocksFormController>();
    }
  }
}
