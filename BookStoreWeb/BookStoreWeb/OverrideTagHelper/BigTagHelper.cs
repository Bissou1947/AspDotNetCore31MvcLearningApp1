using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace BookStoreWeb.OverrideTagHelper
{
    [HtmlTargetElement("big")]
    [HtmlTargetElement(Attributes = "big")]
    public class BigTagHelper: TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h6";
            output.Attributes.RemoveAll("big");
            output.Attributes.SetAttribute("class","h3");
            output.PreContent.SetHtmlContent("Override tage and attribute");
        }
    }
}
