using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace shift6.Models;

public partial class Teacher
{
    public int Id { get; set; }

    [DisplayName("Teacher Name")]
    public string Name { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }
}
