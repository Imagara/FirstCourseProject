﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kusach
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EDM : DbContext
    {
        public EDM()
            : base("name=EDM")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dispatcher> Dispatcher { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<DriversList> DriversList { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<PointsList> PointsList { get; set; }
        public virtual DbSet<RouteList> RouteList { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
    }
}
