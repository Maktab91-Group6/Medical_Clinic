﻿using Clinic_Project.Models.DoctorAgg;

namespace Clinic_Project.Models.SkillAgg;

public partial class Skill
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
