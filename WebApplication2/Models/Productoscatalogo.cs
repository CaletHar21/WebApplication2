using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Productoscatalogo
{
    public int Productoscatalogoid { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Productosactivosdetalle> Productosactivosdetalles { get; set; } = new List<Productosactivosdetalle>();
}
