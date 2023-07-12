using System;
using System.Collections.Generic;

namespace WebApplicationMVC.Models;

public partial class Student
{
    public int StudentNo { get; set; }

    public string Name { get; set; } = null!;

    public int Section { get; set; }

    public string Branch { get; set; } = null!;

    public string EmailId { get; set; } = null!;
}
