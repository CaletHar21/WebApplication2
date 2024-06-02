using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Usuario
{
    public int Usuarioid { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int Nivelaccesoid { get; set; }

    public virtual Accesonivele Nivelacceso { get; set; } = null!;
}
