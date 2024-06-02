using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class BancaonlinesvContext : DbContext
{
    public BancaonlinesvContext()
    {
    }
    public BancaonlinesvContext(DbContextOptions<BancaonlinesvContext> options)
           : base(options)
    {
    }

    public virtual DbSet<Accesonivele> Accesoniveles { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<Cuentadetalle> Cuentadetalles { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Prestamosdetalle> Prestamosdetalles { get; set; }

    public virtual DbSet<Productosactivosdetalle> Productosactivosdetalles { get; set; }

    public virtual DbSet<Productoscatalogo> Productoscatalogos { get; set; }

    public virtual DbSet<Tarjeta> Tarjetas { get; set; }

    public virtual DbSet<Tarjetasdetalle> Tarjetasdetalles { get; set; }

    public virtual DbSet<Tipocuenta> Tipocuentas { get; set; }

    public virtual DbSet<Tipotarjeta> Tipotarjetas { get; set; }

    public virtual DbSet<Tipotransaccione> Tipotransacciones { get; set; }

    public virtual DbSet<Tipotransaccionestarjeta> Tipotransaccionestarjetas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=banca-sql.database.windows.net;Database=BANCAONLINESV;User Id=DMB;Password=Temporal#01;");

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesonivele>(entity =>
        {
            entity.HasKey(e => e.Accesonivelid).HasName("PK__ACCESONI__C69E45375DEF9EB7");

            entity.ToTable("ACCESONIVELES");

            entity.Property(e => e.Accesonivelid).HasColumnName("ACCESONIVELID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Clienteid).HasName("PK__CLIENTES__566BBD8B99FD7F5B");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.Clienteid).HasColumnName("CLIENTEID");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ALIAS");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.Cuentaid).HasName("PK__CUENTAS__E9E5252BFCF26D0C");

            entity.ToTable("CUENTAS");

            entity.Property(e => e.Cuentaid).HasColumnName("CUENTAID");
            entity.Property(e => e.Clienteid).HasColumnName("CLIENTEID");
            entity.Property(e => e.Fechaapertura).HasColumnName("FECHAAPERTURA");
            entity.Property(e => e.Fechacierre).HasColumnName("FECHACIERRE");
            entity.Property(e => e.Ncuenta).HasColumnName("NCUENTA");
            entity.Property(e => e.Productosactivosdetalleid).HasColumnName("PRODUCTOSACTIVOSDETALLEID");
            entity.Property(e => e.Tipocuentaid).HasColumnName("TIPOCUENTAID");

            entity.HasOne(d => d.Productosactivosdetalle).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.Productosactivosdetalleid)
                .HasConstraintName("FK__CUENTAS__PRODUCT__797309D9");

            entity.HasOne(d => d.Tipocuenta).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.Tipocuentaid)
                .HasConstraintName("FK__CUENTAS__TIPOCUE__6B24EA82");
        });

        modelBuilder.Entity<Cuentadetalle>(entity =>
        {
            entity.HasKey(e => e.Cuentadetalleid).HasName("PK__CUENTADE__A2FFB3B053310AAA");

            entity.ToTable("CUENTADETALLES");

            entity.Property(e => e.Cuentadetalleid).HasColumnName("CUENTADETALLEID");
            entity.Property(e => e.Cuentaid).HasColumnName("CUENTAID");
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DETALLE");
            entity.Property(e => e.Fechatrasaccion).HasColumnName("FECHATRASACCION");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("SALDO");
            entity.Property(e => e.Tipotransaccionid).HasColumnName("TIPOTRANSACCIONID");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Cuentadetalles)
                .HasForeignKey(d => d.Cuentaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CUENTADET__CUENT__787EE5A0");

            entity.HasOne(d => d.Tipotransaccion).WithMany(p => p.Cuentadetalles)
                .HasForeignKey(d => d.Tipotransaccionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CUENTADET__TIPOT__778AC167");

            entity.Property(e => e.Abono)
            .HasColumnType("decimal(15, 2)")
            .HasColumnName("ABONO");

            entity.Property(e => e.Retiro)
       .HasColumnType("decimal(15, 2)")
       .HasColumnName("RETIRO");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Prestamoid).HasName("PK__PRESTAMO__C23FC9A81DB69342");

            entity.ToTable("PRESTAMOS");

            entity.Property(e => e.Prestamoid).HasColumnName("PRESTAMOID");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("MONTO");
            entity.Property(e => e.Productosactivosdetalleid).HasColumnName("PRODUCTOSACTIVOSDETALLEID");
            entity.Property(e => e.Productoscatalogoid).HasColumnName("PRODUCTOSCATALOGOID");
            entity.Property(e => e.Tasainteres)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TASAINTERES");
            entity.Property(e => e.Tiempo).HasColumnName("TIEMPO");

            entity.HasOne(d => d.Productosactivosdetalle).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Productosactivosdetalleid)
                .HasConstraintName("FK__PRESTAMOS__PRODU__7B5B524B");

            entity.HasOne(d => d.Productoscatalogo).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Productoscatalogoid)
                .HasConstraintName("FK__PRESTAMOS__PRODU__70DDC3D8");
        });

        modelBuilder.Entity<Prestamosdetalle>(entity =>
        {
            entity.HasKey(e => e.Detalleid).HasName("PK__PRESTAMO__1C1CEE38D10E8D66");

            entity.ToTable("PRESTAMOSDETALLE");

            entity.Property(e => e.Detalleid).HasColumnName("DETALLEID");
            entity.Property(e => e.Fechapago).HasColumnName("FECHAPAGO");
            entity.Property(e => e.Montopago)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTOPAGO");
            entity.Property(e => e.Prestamoid).HasColumnName("PRESTAMOID");
            entity.Property(e => e.SaldoRestante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO_RESTANTE");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.Prestamosdetalles)
                .HasForeignKey(d => d.Prestamoid)
                .HasConstraintName("FK__PRESTAMOS__PREST__14270015");
        });

        modelBuilder.Entity<Productosactivosdetalle>(entity =>
        {
            entity.HasKey(e => e.Productosactivosdetalleid).HasName("PK__PRODUCTO__8DA0EF546026F6D0");

            entity.ToTable("PRODUCTOSACTIVOSDETALLE");

            entity.Property(e => e.Productosactivosdetalleid).HasColumnName("PRODUCTOSACTIVOSDETALLEID");
            entity.Property(e => e.Activo).HasColumnName("ACTIVO");
            entity.Property(e => e.Clienteid).HasColumnName("CLIENTEID");
            entity.Property(e => e.Fechaapertura).HasColumnName("FECHAAPERTURA");
            entity.Property(e => e.Fechacierre).HasColumnName("FECHACIERRE");
            entity.Property(e => e.Productoscatalogoid).HasColumnName("PRODUCTOSCATALOGOID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Productosactivosdetalles)
                .HasForeignKey(d => d.Clienteid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTOS__CLIEN__73BA3083");

            entity.HasOne(d => d.Productoscatalogo).WithMany(p => p.Productosactivosdetalles)
                .HasForeignKey(d => d.Productoscatalogoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTOS__PRODU__74AE54BC");
        });

        modelBuilder.Entity<Productoscatalogo>(entity =>
        {
            entity.HasKey(e => e.Productoscatalogoid).HasName("PK__PRODUCTO__BD1585E2456B4A46");

            entity.ToTable("PRODUCTOSCATALOGOS");

            entity.Property(e => e.Productoscatalogoid).HasColumnName("PRODUCTOSCATALOGOID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.HasKey(e => e.Tarjetaid).HasName("PK__TARJETAS__1B13ABFD544AA6A4");

            entity.ToTable("TARJETAS");

            entity.Property(e => e.Tarjetaid).HasColumnName("TARJETAID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Productosactivosdetalleid).HasColumnName("PRODUCTOSACTIVOSDETALLEID");
            entity.Property(e => e.Tipotarjetaid).HasColumnName("TIPOTARJETAID");
            entity.Property(e => e.Uniquetarjetanumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UNIQUETARJETANUMBER");

            entity.HasOne(d => d.Productosactivosdetalle).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.Productosactivosdetalleid)
                .HasConstraintName("FK__TARJETAS__PRODUC__7A672E12");

            entity.HasOne(d => d.Tipotarjeta).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.Tipotarjetaid)
                .HasConstraintName("FK__TARJETAS__TIPOTA__6E01572D");
        });

        modelBuilder.Entity<Tarjetasdetalle>(entity =>
        {
            entity.HasKey(e => e.Tarjetasdetallesid).HasName("PK__TARJETAS__A3E88B0B8D33AD32");

            entity.ToTable("TARJETASDETALLES");

            entity.Property(e => e.Tarjetasdetallesid).HasColumnName("TARJETASDETALLESID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO");
            entity.Property(e => e.Tarjetaid).HasColumnName("TARJETAID");
            entity.Property(e => e.Tipotransaccionestarjetaid).HasColumnName("TIPOTRANSACCIONESTARJETAID");
            entity.Property(e => e.Transaccionid).HasColumnName("TRANSACCIONID");

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Tarjetasdetalles)
                .HasForeignKey(d => d.Tarjetaid)
                .HasConstraintName("FK__TARJETASD__TARJE__0E6E26BF");
        });

        modelBuilder.Entity<Tipocuenta>(entity =>
        {
            entity.HasKey(e => e.Tipocuentaid).HasName("PK__TIPOCUEN__426632C5E2CB9601");

            entity.ToTable("TIPOCUENTAS");

            entity.Property(e => e.Tipocuentaid).HasColumnName("TIPOCUENTAID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tipotarjeta>(entity =>
        {
            entity.HasKey(e => e.Tipotarjetaid).HasName("PK__TIPOTARJ__15FDF1267B0B27FD");

            entity.ToTable("TIPOTARJETAS");

            entity.Property(e => e.Tipotarjetaid).HasColumnName("TIPOTARJETAID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PorcentajeInteres)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PORCENTAJE_INTERES");
            entity.Property(e => e.Tiempo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TIEMPO");
        });

        modelBuilder.Entity<Tipotransaccione>(entity =>
        {
            entity.HasKey(e => e.Tipotransaccionid).HasName("PK__TIPOTRAN__1B7CD1A2479A4EC6");

            entity.ToTable("TIPOTRANSACCIONES");

            entity.Property(e => e.Tipotransaccionid).HasColumnName("TIPOTRANSACCIONID");
            entity.Property(e => e.Nombretrasact)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRETRASACT");
        });

        modelBuilder.Entity<Tipotransaccionestarjeta>(entity =>
        {
            entity.HasKey(e => e.Tipotransaccionestarjetaid).HasName("PK__TIPOTRAN__025F4D57D38FC6BF");

            entity.ToTable("TIPOTRANSACCIONESTARJETAS");

            entity.Property(e => e.Tipotransaccionestarjetaid)
                .ValueGeneratedOnAdd()
                .HasColumnName("TIPOTRANSACCIONESTARJETAID");
            entity.Property(e => e.Tipotarjetaid)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TIPOTARJETAID");

            entity.HasOne(d => d.TipotransaccionestarjetaNavigation).WithOne(p => p.Tipotransaccionestarjeta)
                .HasForeignKey<Tipotransaccionestarjeta>(d => d.Tipotransaccionestarjetaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TIPOTRANS__TIPOT__114A936A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usuarioid).HasName("PK__USUARIOS__87968D308EA411BF");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Usuarioid).HasColumnName("USUARIOID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.Nivelaccesoid).HasColumnName("NIVELACCESOID");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");

            entity.HasOne(d => d.Nivelacceso).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Nivelaccesoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIOS__NIVELA__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
