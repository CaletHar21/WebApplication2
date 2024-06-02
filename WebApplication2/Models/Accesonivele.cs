using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Accesonivele
{
    public int Accesonivelid { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
