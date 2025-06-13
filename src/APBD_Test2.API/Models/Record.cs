using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Record
{
    public int Id { get; set; }

    public int LanguageId { get; set; }

    public int TaskId { get; set; }

    public int StudentId { get; set; }

    public long ExecutionTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
