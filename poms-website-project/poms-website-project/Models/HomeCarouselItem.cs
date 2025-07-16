using System;
using System.Collections.Generic;

namespace poms_website_project;

public partial class HomeCarouselItem
{
    public int CarouselItemId { get; set; }

    public string ImagePath { get; set; } = null!;

    public string? CaptionTitle { get; set; }

    public string? CaptionText { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public int UploadedBy { get; set; }

    public DateTime UploadedAt { get; set; }
}
