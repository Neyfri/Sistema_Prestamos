﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login_Test.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class base1Entities : DbContext
    {
        public base1Entities()
            : base("name=base1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ahorro> ahorros { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<fiador> fiadors { get; set; }
        public virtual DbSet<garantia> garantias { get; set; }
        public virtual DbSet<inversione> inversiones { get; set; }
        public virtual DbSet<modulo> moduloes { get; set; }
        public virtual DbSet<operacione> operaciones { get; set; }
        public virtual DbSet<prestamo> prestamos { get; set; }
        public virtual DbSet<rol_operacion> rol_operacion { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<tipo_garantia> tipo_garantia { get; set; }
        public virtual DbSet<tipo_pago> tipo_pago { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<pago> pagos { get; set; }
    }
}
