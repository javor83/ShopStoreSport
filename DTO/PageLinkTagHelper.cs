using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ShopStoreSport.DTO
{

   
    public class PageLinkTagHelper : TagHelper
    {
        //************************************************************
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        //************************************************************
        public IUrlHelperFactory fc { get; set; }
        //************************************************************
        public PageLinkTagHelper(IUrlHelperFactory url)
        {
            this.fc = url;
        }
        //************************************************************
        public PageSizeDTO PagingInfo { get; set; }

        //************************************************************

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            if (this.ViewContext != null && this.PagingInfo != null)
            {
                TagBuilder tag_ul = new TagBuilder("ul");
               
              
                tag_ul.AddCssClass("pagination");

                for (int i = 1; i <= this.PagingInfo.TotalPages(); i++)
                {
                    TagBuilder tag_li = new TagBuilder("li");
                    if (i == this.PagingInfo.CurrentPage)
                    {
                        tag_li.AddCssClass("page-item active");
                    }
                    else
                    {
                        tag_li.AddCssClass("page-item");
                    }
                    
                    //-----------------------
                    TagBuilder tag_a = new TagBuilder("a");
                    tag_a.AddCssClass("page-link");
                    tag_a.Attributes["href"] =
                        this.fc.GetUrlHelper(this.ViewContext).Action
                        (
                            new UrlActionContext()
                            {
                                Action = "Index",
                                Controller = "Home",
                                Values = new
                                {
                                    productPage = i
                                }
                            }
                        );

                    tag_a.InnerHtml.Append(Convert.ToString(i));
                    tag_li.InnerHtml.AppendHtml(tag_a);
                    //-----------------------
                    tag_ul.InnerHtml.AppendHtml(tag_li);
                }

                output.Content.AppendHtml(tag_ul);
            }
        }
        //************************************************************
    }
}
