using System;
using System.Collections.Generic;

namespace Client.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string Group { get; set; } = null!;
}
