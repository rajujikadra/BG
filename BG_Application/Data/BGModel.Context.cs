﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BG_Application.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BG_DBEntities : DbContext
    {
        public BG_DBEntities()
            : base("name=BG_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CertificateMst> CertificateMsts { get; set; }
        public virtual DbSet<ColorMst> ColorMsts { get; set; }
        public virtual DbSet<CutMst> CutMsts { get; set; }
        public virtual DbSet<FancyColorMst> FancyColorMsts { get; set; }
        public virtual DbSet<FancyOTMst> FancyOTMsts { get; set; }
        public virtual DbSet<FlouMst> FlouMsts { get; set; }
        public virtual DbSet<HAMst> HAMsts { get; set; }
        public virtual DbSet<PurityMst> PurityMsts { get; set; }
        public virtual DbSet<ShapeMst> ShapeMsts { get; set; }
        public virtual DbSet<CompanyMst> CompanyMsts { get; set; }
        public virtual DbSet<SizeMst> SizeMsts { get; set; }
        public virtual DbSet<PartyMst> PartyMsts { get; set; }
        public virtual DbSet<MainMenuMst> MainMenuMsts { get; set; }
        public virtual DbSet<MenuMst> MenuMsts { get; set; }
    }
}
