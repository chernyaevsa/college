using System;
using System.Collections.Generic;

namespace Client.Models;

public partial class Student
{
    public int id { get; set; }

    public string surname { get; set; } = "Фамилия";

    public string name { get; set; } = "Имя";

    public string patronymic { get; set; } = "Отчество";

    public string dateOfBirth { get; set; } = "20.11.2023";

    public string group { get; set; } = "АА-01";
}
