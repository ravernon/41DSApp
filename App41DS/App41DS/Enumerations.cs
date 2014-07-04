using System;

namespace App41DS
{
    [Flags]
    public enum WebsiteFunctionality
    {
        None = 0,

        HorizontalNavigation = 1,

        VerticalNavigation = 2,

        PhotoGallery = 4,

        VideoGallery = 8,

        ENewsletter = 16,

        Blog = 32,

        ContactForm = 64,

        ContentManagementSystem = 128,

        SocialMediaSharing = 256,

        ThirdPartyPlugins = 512
    }

    [Flags]
    public enum ResponsiveDevices
    {
        None = 0,

        Phone = 1,

        Tablet = 2,

        Desktop = 4,

        Laptop = 8
    }
}