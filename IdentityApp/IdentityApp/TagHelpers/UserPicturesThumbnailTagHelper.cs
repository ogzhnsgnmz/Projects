﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IdentityApp.TagHelpers;

public class UserPicturesThumbnailTagHelper:TagHelper
{
    public string? PictureUrl { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "img";

        if (string.IsNullOrEmpty(PictureUrl))
        {
            output.Attributes.SetAttribute("src", "/userpictures/default.jpg");
        }
        else
        {
            output.Attributes.SetAttribute("src", $"/userpictures/{PictureUrl}");
        }
    }
}
