using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tarjeta
{
    public int Tarjetaid { get; set; }

    public string Uniquetarjetanumber { get; set; } = null!;

    public string? Codigo { get; set; }

    public int? Tipotarjetaid { get; set; }

    public int? Productosactivosdetalleid { get; set; }

    public virtual Productosactivosdetalle? Productosactivosdetalle { get; set; }

    public virtual ICollection<Tarjetasdetalle> Tarjetasdetalles { get; set; } = new List<Tarjetasdetalle>();

    public virtual Tipotarjeta? Tipotarjeta { get; set; }
    public decimal MontoOtorgado { get; set; }

}
