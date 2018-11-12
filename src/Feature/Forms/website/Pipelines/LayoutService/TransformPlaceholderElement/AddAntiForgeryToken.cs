using System.Web;
using System.Web.Helpers;
using CoreySmith.Foundation.LayoutService.ItemRendering;
using CoreySmith.Foundation.LayoutService.Pipelines.LayoutService.TransformPlaceholderElement;
using HtmlAgilityPack;
using Sitecore.Data.Fields;

namespace CoreySmith.Feature.Forms.Pipelines.LayoutService.TransformPlaceholderElement
{
  public class AddAntiForgeryToken : TransformPlaceholderElementProcessor
  {
    public override void TransformPlaceholderElement(TransformPlaceholderElementPipelineArgs args)
    {
      if (!(args.Element is ExtensibleRenderedJsonRendering extensibleRendering)) return;
      if (!ShouldAddAntiForgeryToken(extensibleRendering)) return;

      var antiForgeryTokenHtml = AntiForgery.GetHtml();
      var (name, value) = ParseAntiForgeryToken(antiForgeryTokenHtml);
      args.Result.antiForgeryToken = new
      {
        name,
        value
      };
    }

    private static bool ShouldAddAntiForgeryToken(ExtensibleRenderedJsonRendering extensibleRendering)
    {
      var rendering = extensibleRendering?.Rendering?.RenderingItem?.InnerItem;
      if (rendering == null) return false;

      var addAntiForgeryTokenField = (CheckboxField)rendering.Fields[Templates.JsonRendering.Fields.AddAntiForgeryToken];
      return addAntiForgeryTokenField?.Checked ?? false;
    }

    private static (string Name, string Value) ParseAntiForgeryToken(HtmlString antiForgeryTokenHtml)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(antiForgeryTokenHtml.ToString());
      var input = doc.DocumentNode.SelectSingleNode("//input");
      return (input.Attributes["name"].Value, input.Attributes["value"].Value);
    }
  }
}
