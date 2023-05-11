using System;
using System.Collections.Generic;
using Clinic_Project.Models.DoctorAgg;

namespace Clinic_Project.Models.TurnAgg;

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

    public Turn(DateTime starTime, DateTime endTime, int doctorId)
    {
        StartTime = starTime;
        EndTime = endTime;
        DoctorId = doctorId;
    }
}
