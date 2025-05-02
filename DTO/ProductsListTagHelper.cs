using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ShopStoreSport.DTO
{

    public class ProductsListTagHelper : TagHelper
    {
        private IUrlHelperFactory fc = null;
      
        //******************************************************************
        public ProductsListTagHelper(IUrlHelperFactory url)
        { 
            this.fc = url;
            
        }
        //******************************************************************
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        //******************************************************************
        public int TotalCount { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        //******************************************************************

        private void InsertHeader(string caption,TagBuilder parent)
        {
            TagBuilder tag_th = new TagBuilder("th");
            tag_th.AddCssClass("text-center");

            tag_th.InnerHtml.Append(caption);


            parent.InnerHtml.AppendHtml(tag_th);
        }
        //******************************************************************

        private void InsertProductDescription(string descr,string img,TagBuilder parent)
        {
            TagBuilder tag_td = new TagBuilder("td");
            //--------------
            TagBuilder tag_div = new TagBuilder("div");
            tag_div.InnerHtml.AppendHtml(descr);
            tag_td.InnerHtml.AppendHtml(tag_div);
            //--------------
            TagBuilder tag_img = new TagBuilder("img");
            tag_img.AddCssClass("mt-1 rounded mx-auto d-block");
            tag_img.Attributes.Add("style", "width:100px");
            tag_img.Attributes.Add("alt", "image...");
            tag_img.Attributes.Add("src", img);

            tag_td.InnerHtml.AppendHtml(tag_img);
            //--------------
            parent.InnerHtml.AppendHtml(tag_td);
          
        }
        //******************************************************************
        private void InsertProduct(string caption, TagBuilder parent,string class_name="text-center")
        {
            TagBuilder tag_th = new TagBuilder("td");
            if (class_name != "")
            {
                tag_th.AddCssClass(class_name);
            }

            tag_th.InnerHtml.Append(caption);


            parent.InnerHtml.AppendHtml(tag_th);
        }
        //******************************************************************
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            var current_helper = this.fc.GetUrlHelper(this.ViewContext);
            if (Products.Count() == 0)
            {
                TagBuilder tag_h4 = new TagBuilder("h4");
                tag_h4.InnerHtml.Append(@ProductDTO_caption.Empty);

                output.Content.AppendHtml(tag_h4);
            }
            else
            {
                TagBuilder tag_h4 = new TagBuilder("h4");

                tag_h4.InnerHtml.AppendHtml($"{ProductDTO_caption.Count} {TotalCount}");

                output.Content.AppendHtml(tag_h4);
                //-----------------------
                TagBuilder tag_table = new TagBuilder("table");
                tag_table.AddCssClass("table table-hover table-striped");

                output.Content.AppendHtml(tag_table);
                //-----------------------
                TagBuilder tag_th = new TagBuilder("tr");


                this.InsertHeader(ProductDTO_caption.ID, tag_th);
                this.InsertHeader(ProductDTO_caption.Name, tag_th);
                this.InsertHeader(ProductDTO_caption.Category, tag_th);
                this.InsertHeader(ProductDTO_caption.Price, tag_th);
                this.InsertHeader(ProductDTO_caption.Descr, tag_th);



                tag_table.InnerHtml.AppendHtml(tag_th);





                foreach (ProductDTO item in this.Products)
                {
                    TagBuilder tag_row = new TagBuilder("tr");

                    InsertProduct(Convert.ToString(item.ID), tag_row);
                    InsertProduct(Convert.ToString(item.Category), tag_row, "");
                    InsertProduct(Convert.ToString(item.Category), tag_row);
                    InsertProduct(Convert.ToString(item.Price.ToMoney()), tag_row);
                    InsertProductDescription(item.Description, item.Preview.HTMLImgProduct(), tag_row);
                    tag_table.InnerHtml.AppendHtml(tag_row);
                }




            }
        }
        //******************************************************************
    }
}
