﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiFruverSAS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbFruverEntities : DbContext
    {
        public dbFruverEntities()
            : base("name=dbFruverEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public virtual DbSet<tblCargo> tblCargoes { get; set; }
        public virtual DbSet<tblClasifcProducto> tblClasifcProductoes { get; set; }
        public virtual DbSet<tblCliente> tblClientes { get; set; }
        public virtual DbSet<tblCuidad> tblCuidads { get; set; }
        public virtual DbSet<tblDepartamento> tblDepartamentoes { get; set; }
        public virtual DbSet<tblDireccionCliente> tblDireccionClientes { get; set; }
        public virtual DbSet<tblDireccionEmpleado> tblDireccionEmpleadoes { get; set; }
        public virtual DbSet<tblEmpleado> tblEmpleadoes { get; set; }
        public virtual DbSet<tblFormaDePago> tblFormaDePagoes { get; set; }
        public virtual DbSet<tblGenero> tblGeneroes { get; set; }
        public virtual DbSet<tblPedido> tblPedidoes { get; set; }
        public virtual DbSet<tblPedido_Direc> tblPedido_Direc { get; set; }
        public virtual DbSet<tblProducto> tblProductoes { get; set; }
        public virtual DbSet<tblTelefonoCliente> tblTelefonoClientes { get; set; }
        public virtual DbSet<tblTelefonoEmpleado> tblTelefonoEmpleadoes { get; set; }
        public virtual DbSet<tblTipo_Venta> tblTipo_Venta { get; set; }
        public virtual DbSet<tbltipoDoc> tbltipoDocs { get; set; }
        public virtual DbSet<tblTipoTel> tblTipoTels { get; set; }
        public virtual DbSet<tblUsuario> tblUsuarios { get; set; }
    }
}
