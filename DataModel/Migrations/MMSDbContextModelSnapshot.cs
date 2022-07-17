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

            modelBuilder.Entity("DataModel.Identity.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

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

                    b.Property<string>("birthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("homeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hrId")
                        .HasColumnType("int");

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

                    b.Property<string>("subCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("timeLimit")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("woreda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("hrId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataModel.Models.Entities.CustomerWarranty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("warrantyId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("customerId")
                        .HasColumnType("int");

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

                    b.HasKey("id");

                    b.HasIndex("customerId");

                    b.ToTable("CustemerWarranties");
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

                    b.HasKey("id");

                    b.HasIndex("approveId");

                    b.ToTable("Distributes");
                });

            modelBuilder.Entity("DataModel.Models.Entities.HR", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("hrId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("fpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("higherDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("occpation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reponsibilty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Hrs");
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

                    b.HasData(
                        new
                        {
                            id = 1,
                            attachments = "Upload your Attachment",
                            itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች"
                        },
                        new
                        {
                            id = 2,
                            attachments = "Upload your Attachment",
                            itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች"
                        });
                });

            modelBuilder.Entity("DataModel.Models.Entities.NotifyItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notifyItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            id = 1,
                            model = "ክላሽ ጠብመንጃ",
                            name = "ክላሽ ጠብመንጃ",
                            notifyHeaderId = 1,
                            quantity = 10,
                            type = "ክላሽ ጠብመንጃ"
                        },
                        new
                        {
                            id = 2,
                            model = "ክላሽ ጠብመንጃ ካርታ",
                            name = "ክላሽ ጠብመንጃ ካርታ",
                            notifyHeaderId = 2,
                            quantity = 10,
                            type = "ክላሽ ጠብመንጃ ካርታ"
                        },
                        new
                        {
                            id = 3,
                            model = "የፒኬአም መተረየስ",
                            name = "የፒኬአም መተረየስ",
                            notifyHeaderId = 1,
                            quantity = 10,
                            type = "የፒኬአም መተረየስ"
                        },
                        new
                        {
                            id = 4,
                            model = "ካኑኒ ኤስ ሽጉጥ",
                            name = "ካኑኒ ኤስ ሽጉጥ",
                            notifyHeaderId = 2,
                            quantity = 10,
                            type = "ካኑኒ ኤስ ሽጉጥ"
                        },
                        new
                        {
                            id = 5,
                            model = "ጠብመንጃ AK-47",
                            name = "ክላሽ ጠብመንጃ AK-47",
                            notifyHeaderId = 2,
                            quantity = 10,
                            type = "ክላሽ ጠብመንጃ"
                        });
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

                    b.Property<int>("hrId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("hrId");

                    b.ToTable("RequestHeaders");
                });

            modelBuilder.Entity("DataModel.Models.Entities.RequestItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("requestItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("approvedQuantity")
                        .HasColumnType("int");

                    b.Property<string>("attachments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("DataModel.Models.Entities.ReturnHeader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("returnHeaderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("attachments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hrId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("hrId");

                    b.ToTable("ReturnHeaders");
                });

            modelBuilder.Entity("DataModel.Models.Entities.ReturnItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("returnItemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("attachments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("returnHeaderId")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("returnHeaderId");

                    b.ToTable("ReturnItems");
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

                    b.HasData(
                        new
                        {
                            id = 1,
                            donor = "የኢትዮጵያ መከላከያ",
                            itemNoInExpenditureRegister = "no. 1",
                            noOfEntryInTheRegisterOfIncomingGoods = "10 items",
                            notifyHeaderId = 0
                        },
                        new
                        {
                            id = 2,
                            donor = "የኢትዮጵያ መከላከያ",
                            itemNoInExpenditureRegister = "no. 2",
                            noOfEntryInTheRegisterOfIncomingGoods = "10 items",
                            notifyHeaderId = 0
                        });
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

                    b.HasData(
                        new
                        {
                            id = 1,
                            availability = true,
                            availableQuantity = 10,
                            itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                            model = "ክላሽ ጠብመንጃ",
                            quantity = 10,
                            serialNo = "serial 1",
                            shelfNo = "No. 1",
                            storeHeaderId = 1,
                            storeNo = "No. 1",
                            type = "ክላሽ ጠብመንጃ"
                        },
                        new
                        {
                            id = 2,
                            availability = true,
                            availableQuantity = 10,
                            itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                            model = "ክላሽ ጠብመንጃ ካርታ",
                            quantity = 10,
                            serialNo = "serial 2",
                            shelfNo = "No 2",
                            storeHeaderId = 1,
                            storeNo = "No. 1",
                            type = "ክላሽ ጠብመንጃ ካርታ"
                        },
                        new
                        {
                            id = 3,
                            availability = true,
                            availableQuantity = 10,
                            itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                            model = "የፒኬአም መተረየስ",
                            quantity = 10,
                            serialNo = "serial 3",
                            shelfNo = "",
                            storeHeaderId = 2,
                            storeNo = "",
                            type = "የፒኬአም መተረየስ"
                        },
                        new
                        {
                            id = 4,
                            availability = true,
                            availableQuantity = 10,
                            itemDescription = "የኢትዮጵያ መከላከያ መሳሪያዎችና ጥይቶች",
                            model = "ክላሽ ጠብመንጃ AK-47",
                            quantity = 10,
                            serialNo = "serial 4",
                            shelfNo = "No 2",
                            storeHeaderId = 1,
                            storeNo = "No. 1",
                            type = "ክላሽ ጠብመንጃ"
                        },
                        new
                        {
                            id = 5,
                            availability = true,
                            availableQuantity = 10,
                            itemDescription = "የፌደራል ፖሊስ የክላሽ ጠብመንጃዎችና ጥይች",
                            model = "ካኑኒ ኤስ ሽጉጥ",
                            quantity = 10,
                            serialNo = "serial 5",
                            shelfNo = "",
                            storeHeaderId = 2,
                            storeNo = "",
                            type = "ካኑኒ ኤስ ሽጉጥ"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0998dc8d-5837-4102-b664-16bd16d8000d",
                            ConcurrencyStamp = "c646d99f-9202-408b-ac21-e4572c4acc60",
                            Name = "mmd",
                            NormalizedName = "MMD"
                        },
                        new
                        {
                            Id = "c0371e35-5cb2-4bea-ad0c-d737fbdb927f",
                            ConcurrencyStamp = "0f68b6fc-dd9e-48ef-9556-a1b2779a04c4",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "00a59825-d944-401e-920c-3d38e55147da",
                            ConcurrencyStamp = "a808cddb-b208-4709-ad79-bba647d64460",
                            Name = "storeman",
                            NormalizedName = "storeman"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UsersTokens", (string)null);
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

            modelBuilder.Entity("DataModel.Models.Entities.Customer", b =>
                {
                    b.HasOne("DataModel.Models.Entities.HR", "HR")
                        .WithMany()
                        .HasForeignKey("hrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HR");
                });

            modelBuilder.Entity("DataModel.Models.Entities.CustomerWarranty", b =>
                {
                    b.HasOne("DataModel.Models.Entities.Customer", "Customer")
                        .WithMany("CustomerWarranties")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DataModel.Models.Entities.Distribute", b =>
                {
                    b.HasOne("DataModel.Models.Entities.Approve", "Approve")
                        .WithMany()
                        .HasForeignKey("approveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approve");
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

            modelBuilder.Entity("DataModel.Models.Entities.RequestHeader", b =>
                {
                    b.HasOne("DataModel.Models.Entities.HR", "HR")
                        .WithMany()
                        .HasForeignKey("hrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HR");
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

            modelBuilder.Entity("DataModel.Models.Entities.ReturnHeader", b =>
                {
                    b.HasOne("DataModel.Models.Entities.HR", "HR")
                        .WithMany()
                        .HasForeignKey("hrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HR");
                });

            modelBuilder.Entity("DataModel.Models.Entities.ReturnItem", b =>
                {
                    b.HasOne("DataModel.Models.Entities.ReturnHeader", "ReturnHeader")
                        .WithMany("ReturnItems")
                        .HasForeignKey("returnHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReturnHeader");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataModel.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataModel.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataModel.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataModel.Models.Entities.Customer", b =>
                {
                    b.Navigation("CustomerWarranties");
                });

            modelBuilder.Entity("DataModel.Models.Entities.NotifyHeader", b =>
                {
                    b.Navigation("NotifyItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.RequestHeader", b =>
                {
                    b.Navigation("RequestItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.ReturnHeader", b =>
                {
                    b.Navigation("ReturnItems");
                });

            modelBuilder.Entity("DataModel.Models.Entities.StoreHeader", b =>
                {
                    b.Navigation("StoreItems");
                });
#pragma warning restore 612, 618
        }
    }
}
