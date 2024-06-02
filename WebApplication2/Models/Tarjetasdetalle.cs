using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tarjetasdetalle
{
    public int Tarjetasdetallesid { get; set; }

    public int? Tarjetaid { get; set; }

    public int? Transaccionid { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Monto { get; set; }

    public string? Descripcion { get; set; }

    public int? Tipotransaccionestarjetaid { get; set; }

    public virtual Tarjeta? Tarjeta { get; set; }

    public virtual Tipotransaccionestarjeta? Tipotransaccionestarjeta { get; set; }
}
