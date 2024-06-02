using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Prestamo
{
    public int Prestamoid { get; set; }

    public decimal Monto { get; set; }

    public decimal Tasainteres { get; set; }

    public int? Tiempo { get; set; }

    public int? Productoscatalogoid { get; set; }

    public int? Productosactivosdetalleid { get; set; }

    public virtual ICollection<Prestamosdetalle> Prestamosdetalles { get; set; } = new List<Prestamosdetalle>();

    public virtual Productosactivosdetalle? Productosactivosdetalle { get; set; }

    public virtual Productoscatalogo? Productoscatalogo { get; set; }
}
