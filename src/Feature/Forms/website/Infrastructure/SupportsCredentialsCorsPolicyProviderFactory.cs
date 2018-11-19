using System.Net.Http;
using System.Web.Http.Cors;
using Sitecore.Services.Infrastructure.Cors;

namespace CoreySmith.Feature.Forms.Infrastructure
{
  public class SupportsCredentialsCorsPolicyProviderFactory : CorsPolicyProviderFactory
  {
    public SupportsCredentialsCorsPolicyProviderFactory(ICorsConfigurationFactory providerFactory, AttributeBasedPolicyProviderFactory attributeBasedPolicyProviderFactory) 
      : base(providerFactory, attributeBasedPolicyProviderFactory)
    {
    }

    public override ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
    {
      var policyProvider = base.GetCorsPolicyProvider(request);
      if (!(policyProvider is EnableCorsAttribute enableCorsAttribute)) return policyProvider;

      enableCorsAttribute.SupportsCredentials = true;
      return enableCorsAttribute;
    }
  }
}
