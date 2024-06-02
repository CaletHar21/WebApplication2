using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Cuentadetalle
{
    public int Cuentadetalleid { get; set; }

    public DateOnly? Fechatrasaccion { get; set; }

    public decimal Saldo { get; set; }

    public string? Detalle { get; set; }

    public int Tipotransaccionid { get; set; }

    public int Cuentaid { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;

    public virtual Tipotransaccione Tipotransaccion { get; set; } = null!;
    public int Abono { get; set; }
    public int Retiro { get; set; }
}
