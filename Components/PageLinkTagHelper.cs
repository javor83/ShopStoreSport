using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopStoreSport.Models;

namespace ShopStoreSport.Components
{


    public class PageLinkTagHelper : TagHelper
    {
        public string PageController { get; set; }
        //************************************************************
        public string PageAction { get; set; }
        //************************************************************
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        //************************************************************
        public IUrlHelperFactory fc { get; set; }
        //************************************************************
        public PageLinkTagHelper(IUrlHelperFactory url)
        {
            fc = url;
        }
        //************************************************************
        public PageSizeDTO PagingInfo { get; set; }

        public int? Category { get; set; }
        //************************************************************

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            if (ViewContext != null && PagingInfo != null)
            {
                TagBuilder tag_ul = new TagBuilder("ul");


                tag_ul.AddCssClass("pagination");

                for (int i = 1; i <= PagingInfo.TotalPages(); i++)
                {
                    TagBuilder tag_li = new TagBuilder("li");
                    if (i == PagingInfo.CurrentPage)
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
                        fc.GetUrlHelper(ViewContext).Action
                        (
                            new UrlActionContext()
                            {
                                Action = PageAction,
                                Controller = PageController,
                                Values = new
                                {
                                    pindex = i,
                                    category = Category
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
