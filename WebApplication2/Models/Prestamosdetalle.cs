using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Prestamosdetalle
{
    public int Detalleid { get; set; }

    public int? Prestamoid { get; set; }

    public DateOnly? Fechapago { get; set; }

    public decimal? Montopago { get; set; }

    public decimal? SaldoRestante { get; set; }

    public virtual Prestamo? Prestamo { get; set; }
}
