﻿using System;
using System.Collections.Generic;

namespace Client.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountHours { get; set; } = null!;
}
