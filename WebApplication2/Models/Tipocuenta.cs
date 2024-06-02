using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tipocuenta
{
    public int Tipocuentaid { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
