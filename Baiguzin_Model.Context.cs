﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiguzinAutoservice
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Baiguzin_autoserviceEntities : DbContext
    {
        private static Baiguzin_autoserviceEntities _context;
        public static Baiguzin_autoserviceEntities GetContext()
        {
            if (_context == null)
                _context = new Baiguzin_autoserviceEntities();
            return _context;
        }

        public Baiguzin_autoserviceEntities()
            : base("name=Baiguzin_autoserviceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientService> ClientService { get; set; }
        public virtual DbSet<DocumentByService> DocumentByService { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<service_a_import> service_a_import { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhoto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
    }
}
