using System;
using System.Collections.Generic;

namespace WebApplicationMVC.Models;

public partial class Image
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public DateTime? CreatedAt { get; set; }
}
