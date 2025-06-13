using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Descrition { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
