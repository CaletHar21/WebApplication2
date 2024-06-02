using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Cliente
{
    public int Clienteid { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int? Edad { get; set; }

    public string? Direccion { get; set; }

    public string Contrasena { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Alias { get; set; }

    public virtual ICollection<Productosactivosdetalle> Productosactivosdetalles { get; set; } = new List<Productosactivosdetalle>();
}
