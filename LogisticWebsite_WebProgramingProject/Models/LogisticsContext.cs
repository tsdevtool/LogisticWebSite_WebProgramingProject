﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LogisticWebsite_WebProgramingProject.Models;

public partial class LogisticsContext : DbContext
{
    public LogisticsContext()
    {
    }

    public LogisticsContext(DbContextOptions<LogisticsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillOfLading> BillOfLadings { get; set; }

    public virtual DbSet<BookingInfomation> BookingInfomations { get; set; }

    public virtual DbSet<BookingWareHouse> BookingWareHouses { get; set; }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<ContainerBillOfLading> ContainerBillOfLadings { get; set; }

    public virtual DbSet<CostsIncurred> CostsIncurreds { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<Tracking> Trackings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WareHouse> WareHouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-G5HQJSJ2;Initial Catalog=Logistics;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillOfLading>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK_Booking");

            entity.ToTable("BillOfLading");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.ContainerId).HasColumnName("ContainerID");
            entity.Property(e => e.ShipId).HasColumnName("ShipID");

            entity.HasOne(d => d.BookingNoNavigation).WithMany(p => p.BillOfLadings)
                .HasForeignKey(d => d.BookingNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillOfLading_BookingInfomation");

            entity.HasOne(d => d.Container).WithMany(p => p.BillOfLadings)
                .HasForeignKey(d => d.ContainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillOfLading_Container1");

            entity.HasOne(d => d.Ship).WithMany(p => p.BillOfLadings)
                .HasForeignKey(d => d.ShipId)
                .HasConstraintName("FK_BillOfLading_Ship");
        });

        modelBuilder.Entity<BookingInfomation>(entity =>
        {
            entity.HasKey(e => e.BookingNo).HasName("PK_PackageInfomation");

            entity.ToTable("BookingInfomation");

            entity.Property(e => e.Commodity).HasMaxLength(100);
            entity.Property(e => e.CutOffCy).HasColumnName("CutOffCY");
            entity.Property(e => e.CutOffSi).HasColumnName("CutOffSI");
            entity.Property(e => e.CutOffVgm).HasColumnName("CutOffVGM");
            entity.Property(e => e.From).HasMaxLength(200);
            entity.Property(e => e.To).HasMaxLength(200);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.BookingInfomations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingInfomation_User");
        });

        modelBuilder.Entity<BookingWareHouse>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PK_Booking-WhareHouse");

            entity.ToTable("Booking-WareHouse");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.WhareHouseId).HasColumnName("WhareHouseID");

            entity.HasOne(d => d.Bill).WithMany(p => p.BookingWareHouses)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking-WhareHouse_Booking");

            entity.HasOne(d => d.WhareHouse).WithMany(p => p.BookingWareHouses)
                .HasForeignKey(d => d.WhareHouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking-WhareHouse_WhareHouse");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.ToTable("Container");

            entity.Property(e => e.ContainerId)
                .ValueGeneratedNever()
                .HasColumnName("ContainerID");
            entity.Property(e => e.ContainerSize)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PlaceToPickUp).HasMaxLength(100);
        });

        modelBuilder.Entity<ContainerBillOfLading>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ContainerBillOfLading");

            entity.Property(e => e.Container)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<CostsIncurred>(entity =>
        {
            entity.ToTable("CostsIncurred");

            entity.Property(e => e.CostsIncurredId).HasColumnName("CostsIncurredID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Bill).WithMany(p => p.CostsIncurreds)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CostsIncurred_BillOfLading");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Bill");

            entity.ToTable("Invoice");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.CostsIncurredId).HasColumnName("CostsIncurredID");
            entity.Property(e => e.Surcharge).HasColumnType("money");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Bill).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_BillOfLading");

            entity.HasOne(d => d.CostsIncurred).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CostsIncurredId)
                .HasConstraintName("FK_Invoice_CostsIncurred");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedule");

            entity.Property(e => e.Pod)
                .HasMaxLength(80)
                .HasColumnName("POD");
            entity.Property(e => e.Pol)
                .HasMaxLength(80)
                .HasColumnName("POL");
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.ToTable("Ship");

            entity.Property(e => e.ShipId).HasColumnName("ShipID");
            entity.Property(e => e.ShipCode)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.ShipName).HasMaxLength(50);

            entity.HasOne(d => d.Schedule).WithMany(p => p.Ships)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ship_Schedule");
        });

        modelBuilder.Entity<Tracking>(entity =>
        {
            entity.ToTable("Tracking");

            entity.Property(e => e.TrackingId).HasColumnName("TrackingID");
            entity.Property(e => e.BillId).HasColumnName("BillID");

            entity.HasOne(d => d.Bill).WithMany(p => p.Trackings)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tracking_BillOfLading");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserSignUp");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(30)
                .HasColumnName("Country/Region");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<WareHouse>(entity =>
        {
            entity.HasKey(e => e.WhareHouseId).HasName("PK_WhareHouse");

            entity.ToTable("WareHouse");

            entity.Property(e => e.WhareHouseId).HasColumnName("WhareHouseID");
            entity.Property(e => e.Price).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
