using System;
using System.Collections.Generic;

namespace Client.Models;

public partial class Student
{
    public int id { get; set; }

    public string surname { get; set; } = null!;

    public string name { get; set; } = null!;

    public string patronymic { get; set; } = null!;

    public string dateOfBirth { get; set; } = null!;

    public string group { get; set; } = null!;
}
