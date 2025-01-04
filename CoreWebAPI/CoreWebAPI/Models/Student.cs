using System;
using System.Collections.Generic;

namespace CoreWebAPI.Models;

public partial class Student
{
    public long Id { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGender { get; set; }

    public long? Age { get; set; }

    public string? Standard { get; set; }

    public string? FatherName { get; set; }
}
