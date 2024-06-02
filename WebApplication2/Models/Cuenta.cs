using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Cuenta
{
    public int Cuentaid { get; set; }

    public int? Clienteid { get; set; }

    public DateOnly? Fechaapertura { get; set; }

    public DateOnly? Fechacierre { get; set; }

    public int? Tipocuentaid { get; set; }

    public int? Productosactivosdetalleid { get; set; }

    public int? Ncuenta { get; set; }

    public virtual ICollection<Cuentadetalle> Cuentadetalles { get; set; } = new List<Cuentadetalle>();

    public virtual Productosactivosdetalle? Productosactivosdetalle { get; set; }

    public virtual Tipocuenta? Tipocuenta { get; set; }
}
