using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo1.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public short Empid { get; set; }

    public int Employee1Id { get; set; }
}
