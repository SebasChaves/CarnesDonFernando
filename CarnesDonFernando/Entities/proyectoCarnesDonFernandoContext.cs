using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class proyectoCarnesDonFernandoContext : DbContext
    {
        public proyectoCarnesDonFernandoContext()
        {
        }

        public proyectoCarnesDonFernandoContext(DbContextOptions<proyectoCarnesDonFernandoContext> options)
            : base(options)
        {
        }

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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-SEBASTIAN;Database=proyectoCarnesDonFernando;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5A3263D0CB");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PK__detalle___DD5B8F3393E29917");

                entity.ToTable("detalle_orden");

                entity.Property(e => e.IdOrden)
                    .ValueGeneratedNever()
                    .HasColumnName("id_orden");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_o__id_pr__29572725");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.HasKey(e => e.IdIngrediente)
                    .HasName("PK__ingredie__3F505D45F0A42F31");

                entity.ToTable("ingrediente");

                entity.Property(e => e.IdIngrediente)
                    .ValueGeneratedNever()
                    .HasColumnName("id_ingrediente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal)
                    .HasName("PK__local__1ECD0210ED864362");

                entity.ToTable("local");

                entity.Property(e => e.IdLocal)
                    .ValueGeneratedNever()
                    .HasColumnName("id_local");

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
            });

            modelBuilder.Entity<MensajesContacto>(entity =>
            {
                entity.HasKey(e => e.IdMensaje)
                    .HasName("PK__mensajes__5B37C7F649F28021");

                entity.ToTable("mensajes_contacto");

                entity.Property(e => e.IdMensaje)
                    .ValueGeneratedNever()
                    .HasColumnName("id_mensaje");

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
                    .HasConstraintName("FK__mensajes___id_lo__31EC6D26");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__FF341C0D20D0D1A4");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_producto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.DescripcionProductoCorta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcionProductoCorta");

                entity.Property(e => e.DescripcionProductoLarga)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("descripcionProductoLarga");

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
                    .HasConstraintName("FK__producto__id_cat__267ABA7A");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.HasKey(e => e.IdReceta)
                    .HasName("PK__recetas__11DB53ABE76163D9");

                entity.ToTable("recetas");

                entity.Property(e => e.IdReceta)
                    .ValueGeneratedNever()
                    .HasColumnName("id_receta");

                entity.Property(e => e.DescripcionReceta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_receta");

                entity.Property(e => e.IdIngrediente).HasColumnName("id_ingrediente");

                entity.Property(e => e.NombreReceta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_receta");

                entity.HasOne(d => d.IdIngredienteNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recetas__id_ingr__36B12243");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante)
                    .HasName("PK__restaura__5C186E3F2E0D57C9");

                entity.ToTable("restaurante");

                entity.Property(e => e.IdRestaurante)
                    .ValueGeneratedNever()
                    .HasColumnName("id_restaurante");

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
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__4E3E04AD21DD8887");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("id_usuario");

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
