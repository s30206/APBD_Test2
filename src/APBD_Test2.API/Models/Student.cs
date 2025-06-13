using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
