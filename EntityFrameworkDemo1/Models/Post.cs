using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo1.Models;

public partial class Post
{
   
    public int PostId { get; set; }

    public DateTime? DatePublished { get; set; }

    public string? Body { get; set; }

    public string? Title { get; set; }
}
