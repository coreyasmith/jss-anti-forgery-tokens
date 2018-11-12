using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.JavaScriptServices.AppServices.Extensions;
using Sitecore.JavaScriptServices.AppServices.Models;
using Sitecore.JavaScriptServices.AppServices.Pipelines.Import;

namespace CoreySmith.Feature.Forms.Pipelines.JavaScriptServices.Import
{
  public class ProcessRenderingsWithAntiForgeryToken : IImportPipelineProcessor
  {
    public void Process(ImportPipelineArgs args)
    {
      var antiForgeryTokenRenderings = args.ImportData.Renderings.Where(RequiresAntiForgeryToken);
      foreach (var renderingDefinition in antiForgeryTokenRenderings)
      {
        if (!args.RenderingsMap.ContainsKey(renderingDefinition.Name)) continue;

        var renderingId = args.RenderingsMap[renderingDefinition.Name];
        var rendering = args.Items.RenderingsContainer.Database.GetItem(renderingId);
        if (rendering == null) return;

        AddAntiForgeryToken(rendering);
      }
    }

    private static bool RequiresAntiForgeryToken(RenderingDef renderingDefinition)
    {
      var additionalData = renderingDefinition.AdditionalData;
      if (additionalData == null) return false;

      if (!additionalData.ContainsKey("addAntiForgeryToken")) return false;

      bool.TryParse(additionalData["addAntiForgeryToken"].ToString(), out var result);
      return result;
    }

    private static void AddAntiForgeryToken(Item rendering)
    {
      if (!rendering.CanWrite()) return;

      var addAntiForgeryTokenField = (CheckboxField)rendering.Fields[Templates.JsonRendering.Fields.AddAntiForgeryToken];
      if (addAntiForgeryTokenField == null) return;

      rendering.Editing.BeginEdit();
      addAntiForgeryTokenField.Checked = true;
      rendering.Editing.EndEdit();
    }
  }
}
