using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers
{
    [HtmlTargetElement("Input", Attributes = "Autocomplete")]

    public class InputTagHelper : TagHelper
    {
        [HtmlAttributeName("autocomplete")]

        public string AutocompleteStatus { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AutocompleteStatus == "off" || AutocompleteStatus == "false" || AutocompleteStatus == "disable")
            {
                output.Attributes.SetAttribute("autocomplete", "off");

            }
            else
            {
                output.Attributes.SetAttribute("autocomplete", "on");
            }
        }
    }
}
