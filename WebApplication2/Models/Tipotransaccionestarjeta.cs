using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tipotransaccionestarjeta
{
    public int Tipotransaccionestarjetaid { get; set; }

    public string? Tipotarjetaid { get; set; }

    public virtual Tarjetasdetalle TipotransaccionestarjetaNavigation { get; set; } = null!;
}
