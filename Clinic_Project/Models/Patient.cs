using System;
using System.Collections.Generic;
using Clinic_Project.Models.TurnAgg;

namespace Clinic_Project.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Family { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Role { get; set; }

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();
}
