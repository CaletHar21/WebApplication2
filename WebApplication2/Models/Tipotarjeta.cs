using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tipotarjeta
{
    public int Tipotarjetaid { get; set; }

    public string? Nombre { get; set; }

    public decimal? PorcentajeInteres { get; set; }

    public string? Tiempo { get; set; }

    public virtual ICollection<Tarjeta> Tarjeta { get; set; } = new List<Tarjeta>();
}
