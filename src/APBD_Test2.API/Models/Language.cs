using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
