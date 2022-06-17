﻿// <auto-generated />
using System;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataModel.Migrations
{
    [DbContext(typeof(MMSDbContext))]
    partial class MMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataModel.Models.Entities.Approve", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("approveId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"), 1L, 1);

                    b.Property<int>("approvedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("requestId")
                        .HasColumnType("int");

                    b.Property<int>("storeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("requestId");

                    b.HasIndex("storeId");

                    b.ToTable("Approves");
                });

            modelBuilder.Entity("DataModel.Models.Entities.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("birthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bithPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("homeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sub_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("timeLimit")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("warantiyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("warantiyRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("warantiySubCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("warantiyWoreda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("warantiyname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("woreda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataModel.Models.Entities.Distribute", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("distributeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("approveId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("approveId");

                    b.HasIndex("userId");

                    b.ToTable("Distributes");
                });

            modelBuilder.Entity("DataModel.Models.Entities.NotifyHeader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notifyHeaderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("attachments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("NotifyHeaders");
                });

            modelBuilder.Entity("DataModel.Models.Entities.NotifyItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notifyItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("notifyHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("notifyHeaderId");

                    b.ToTable("NotifyItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.RequestHeader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("requestHeaderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("attachments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("RequestHeaders");
                });

            modelBuilder.Entity("DataModel.Models.Entities.RequestItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("requestItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("remainQuantity")
                        .HasColumnType("int");

                    b.Property<int>("requestHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("requestedQuantity")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("requestHeaderId");

                    b.ToTable("RequestItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.StoreHeader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("storeHeaderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("donor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemNoInExpenditureRegister")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("noOfEntryInTheRegisterOfIncomingGoods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("notifyHeaderId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("StoreHeaders");
                });

            modelBuilder.Entity("DataModel.Models.Entities.StoreItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("storeItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("availability")
                        .HasColumnType("bit");

                    b.Property<int>("availableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("itemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("serialNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shelfNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("storeHeaderId")
                        .HasColumnType("int");

                    b.Property<string>("storeNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("storeHeaderId");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.Approve", b =>
                {
                    b.HasOne("DataModel.Models.Entities.RequestItem", "RequestItem")
                        .WithMany()
                        .HasForeignKey("requestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Models.Entities.StoreItem", "StoreItem")
                        .WithMany()
                        .HasForeignKey("storeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestItem");

                    b.Navigation("StoreItem");
                });

            modelBuilder.Entity("DataModel.Models.Entities.Distribute", b =>
                {
                    b.HasOne("DataModel.Models.Entities.Approve", "Approve")
                        .WithMany()
                        .HasForeignKey("approveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approve");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DataModel.Models.Entities.NotifyItem", b =>
                {
                    b.HasOne("DataModel.Models.Entities.NotifyHeader", "NotifyHeader")
                        .WithMany("NotifyItems")
                        .HasForeignKey("notifyHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotifyHeader");
                });

            modelBuilder.Entity("DataModel.Models.Entities.RequestItem", b =>
                {
                    b.HasOne("DataModel.Models.Entities.RequestHeader", "RequestHeader")
                        .WithMany("RequestItems")
                        .HasForeignKey("requestHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestHeader");
                });

            modelBuilder.Entity("DataModel.Models.Entities.StoreItem", b =>
                {
                    b.HasOne("DataModel.Models.Entities.StoreHeader", "StoreHeader")
                        .WithMany("StoreItems")
                        .HasForeignKey("storeHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreHeader");
                });

            modelBuilder.Entity("DataModel.Models.Entities.NotifyHeader", b =>
                {
                    b.Navigation("NotifyItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.RequestHeader", b =>
                {
                    b.Navigation("RequestItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.StoreHeader", b =>
                {
                    b.Navigation("StoreItems");
                });
#pragma warning restore 612, 618
        }
    }
}
