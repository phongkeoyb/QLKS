﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKhachSan
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class quanlykhachsanEntities : DbContext
    {
        public quanlykhachsanEntities()
            : base("name=quanlykhachsanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dichvu> dichvus { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<phong> phongs { get; set; }
        public virtual DbSet<sudungdv> sudungdvs { get; set; }
        public virtual DbSet<thuephong> thuephongs { get; set; }
    }
}
