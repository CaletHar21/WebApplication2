using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Productosactivosdetalle
{
    public int Productosactivosdetalleid { get; set; }

    public int Clienteid { get; set; }

    public DateOnly? Fechaapertura { get; set; }

    public DateOnly? Fechacierre { get; set; }

    public int Productoscatalogoid { get; set; }

    public bool? Activo { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual Productoscatalogo Productoscatalogo { get; set; } = null!;

    public virtual ICollection<Tarjeta> Tarjeta { get; set; } = new List<Tarjeta>();
}
