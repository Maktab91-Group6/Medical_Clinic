﻿using System;
using System.Collections.Generic;

namespace Clinic_Project.Models.Doctor;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Family { get; set; } = null!;

    public int SkillId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Role { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();
}
