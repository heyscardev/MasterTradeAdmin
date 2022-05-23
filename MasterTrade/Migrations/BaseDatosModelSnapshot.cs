﻿// <auto-generated />
using System;
using MasterTrade.Modelo.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MasterTrade.Migrations
{
    [DbContext(typeof(BaseDatos))]
    partial class BaseDatosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Estacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Modulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Operacion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Auditoria");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaNacimento")
                        .HasColumnType("Date");

                    b.Property<string>("Imagen")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TipoIdentificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NumeroIdentificacion")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<int>("NControl")
                        .HasColumnType("int");

                    b.Property<int>("NFactura")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDolar")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.CompraProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CompraProductos");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Impuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Impuesto");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodBarras")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CodProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Imagen")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("PorcentajeGanancia")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Precio1")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("Precio2")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("Precio3")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("StockMax")
                        .HasColumnType("int");

                    b.Property<int?>("StockMin")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDolar")
                        .HasColumnType("decimal(12,2)");

                    b.Property<bool>("Visible")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CodBarras")
                        .IsUnique();

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaNacimento")
                        .HasColumnType("Date");

                    b.Property<string>("Imagen")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TipoIdentificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NumeroIdentificacion")
                        .IsUnique();

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Correo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaNacimento")
                        .HasColumnType("Date");

                    b.Property<string>("Imagen")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TipoIdentificacion")
                        .HasColumnType("int");

                    b.Property<int>("TipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.HasKey("Id");

                    b.HasIndex("NombreUsuario")
                        .IsUnique();

                    b.HasIndex("NumeroIdentificacion")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime");

                    b.Property<int>("NControl")
                        .HasColumnType("int");

                    b.Property<int>("NFactura")
                        .HasColumnType("int");

                    b.Property<int>("NombreVendedor")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDolar")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.VentaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool?>("EstadoBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("DetalleVenta");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Auditoria", b =>
                {
                    b.HasOne("MasterTrade.Modelo.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Compra", b =>
                {
                    b.HasOne("MasterTrade.Modelo.Entidades.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.CompraProducto", b =>
                {
                    b.HasOne("MasterTrade.Modelo.Entidades.Compra", "Compra")
                        .WithMany("CompraProducto")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterTrade.Modelo.Entidades.Producto", "Producto")
                        .WithMany("ComprasProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Venta", b =>
                {
                    b.HasOne("MasterTrade.Modelo.Entidades.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.VentaProducto", b =>
                {
                    b.HasOne("MasterTrade.Modelo.Entidades.Producto", "Producto")
                        .WithMany("VentasProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterTrade.Modelo.Entidades.Venta", "Venta")
                        .WithMany("VentaProducto")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Compra", b =>
                {
                    b.Navigation("CompraProducto");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Producto", b =>
                {
                    b.Navigation("ComprasProductos");

                    b.Navigation("VentasProductos");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Proveedor", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("MasterTrade.Modelo.Entidades.Venta", b =>
                {
                    b.Navigation("VentaProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
