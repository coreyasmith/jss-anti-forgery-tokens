using CoreySmith.Feature.Forms.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace CoreySmith.Feature.Forms
{
  public class FormsConfigurator : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<JssRocksFormController>();
    }
  }
}
