using System;
using System.Collections.Generic;

namespace Clinic_Project.Models;

public partial class Turn
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int DoctorId { get; set; }

    public int? PatientId { get; set; }

    public bool IsReserved { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient? Patient { get; set; }
}
