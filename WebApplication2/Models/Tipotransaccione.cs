using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Tipotransaccione
{
    public int Tipotransaccionid { get; set; }

    public string? Nombretrasact { get; set; }

    public virtual ICollection<Cuentadetalle> Cuentadetalles { get; set; } = new List<Cuentadetalle>();
}
