﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MeuCarroCerto.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class EntidadesMeuCarroCertoDB : DbContext
{
    public EntidadesMeuCarroCertoDB()
        //: base("name=EntidadesMeuCarroCertoDB")
        : base("name=db2c210cb9d468430aa757a57f01269a9d")
        
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<t_marcas> t_marcas { get; set; }

    public virtual DbSet<t_usuarios> t_usuarios { get; set; }

    public virtual DbSet<t_carrocerias> t_carrocerias { get; set; }

    public virtual DbSet<t_criterios> t_criterios { get; set; }

    public virtual DbSet<t_alternativas> t_alternativas { get; set; }

    public virtual DbSet<t_cores> t_cores { get; set; }

    public virtual DbSet<t_carros_teste> t_carros_teste { get; set; }

    public virtual DbSet<t_carros> t_carros { get; set; }

}

}

