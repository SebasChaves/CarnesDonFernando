using System;
using System.Collections.Generic;
using Entities.Authentication;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class pruebasCarnesDonFernandoContext : IdentityDbContext<ApplicationUser>
    {
        public pruebasCarnesDonFernandoContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<pruebasCarnesDonFernandoContext>();
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
        }

        public pruebasCarnesDonFernandoContext(DbContextOptions<pruebasCarnesDonFernandoContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CarritoItem> CarritoItems { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; } = null!;
        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public virtual DbSet<Local> Locals { get; set; } = null!;
        public virtual DbSet<MensajesContacto> MensajesContactos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Receta> Recetas { get; set; } = null!;
        public virtual DbSet<Restaurante> Restaurantes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-SEBASTIAN;Database=pruebasCarnesDonFernando;Integrated Security=True;Trusted_Connection=True;");
            }*/
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.IdCarrito)
                    .HasName("PK__Carrito__83A2AD9C9A106C49");

                entity.ToTable("Carrito");

                entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creado");

                //entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.PrecioFinal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precioFinal");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("id_usuario");


            });

            modelBuilder.Entity<CarritoItem>(entity =>
            {
                entity.HasKey(e => e.IdCarritoItems)
                    .HasName("PK__CarritoI__459388842E59CE49");

                entity.Property(e => e.IdCarritoItems).HasColumnName("id_carritoItems");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdCarritoNavigation)
                    .WithMany(p => p.CarritoItems)
                    .HasForeignKey(d => d.IdCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarritoIt__id_ca__693CA210");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CarritoItems)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarritoIt__id_pr__6A30C649");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5A29C81526");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PK__detalle___DD5B8F33FCE7F379");

                entity.ToTable("detalle_orden");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_o__id_pr__30F848ED");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.HasKey(e => e.IdIngrediente)
                    .HasName("PK__ingredie__3F505D45EF65A75A");

                entity.ToTable("ingrediente");

                entity.Property(e => e.IdIngrediente).HasColumnName("id_ingrediente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithMany(p => p.Ingredientes)
                    .HasForeignKey(d => d.IdReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingredien__id_re__3E52440B");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal)
                    .HasName("PK__local__1ECD0210C340B541");

                entity.ToTable("local");

                entity.Property(e => e.IdLocal).HasColumnName("id_local");

                entity.Property(e => e.Horario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("horario");

                entity.Property(e => e.NombreLocal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_local");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.Property(e => e.UrlImg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("urlImg");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<MensajesContacto>(entity =>
            {
                entity.HasKey(e => e.IdMensaje)
                    .HasName("PK__mensajes__5B37C7F6ECE32B45");

                entity.ToTable("mensajes_contacto");

                entity.Property(e => e.IdMensaje).HasColumnName("id_mensaje");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdLocal).HasColumnName("id_local");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mensaje");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_persona");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.MensajesContactos)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mensajes___id_lo__398D8EEE");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__FF341C0DB26A2CC3");

                entity.ToTable("producto");

                /* entity.Property(e => e.IdProducto)
                     .ValueGeneratedNever()
                     .HasColumnName("id_producto");*/
                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.DescripcionProductoCorta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcionProductoCorta");

                entity.Property(e => e.DescripcionProductoLarga)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("descripcionProductoLarga");

                /*entity.Property(e => e.IdCategoria)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_categoria");*/
                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.UrlImg)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("urlImg");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__id_cat__2E1BDC42");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.HasKey(e => e.IdReceta)
                    .HasName("PK__recetas__11DB53ABF4A6C7D0");

                entity.ToTable("recetas");

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");

                entity.Property(e => e.DescripcionReceta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_receta");

                entity.Property(e => e.NombreReceta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_receta");

                entity.Property(e => e.UrlImg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("urlImg");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante)
                    .HasName("PK__restaura__5C186E3F001224E5");

                entity.ToTable("restaurante");

                entity.Property(e => e.IdRestaurante).HasColumnName("id_restaurante");

                entity.Property(e => e.Horario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("horario");

                entity.Property(e => e.NombreRestaurante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_restaurante");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.Property(e => e.UrlImg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("urlImg");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__4E3E04ADD0F6FC19");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
