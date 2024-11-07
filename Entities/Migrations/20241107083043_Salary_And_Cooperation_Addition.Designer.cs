﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241107083043_Salary_And_Cooperation_Addition")]
    partial class Salary_And_Cooperation_Addition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("Gender")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool?>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<Guid?>("JobCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LeastAcademicDegree")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LeastYearsOfExperience")
                        .HasColumnType("int");

                    b.Property<string>("MilitaryServiceStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NotVerificationDescription")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("SalaryAmount")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SalaryID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TypeOfCooperation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobCategoryId");

                    b.HasIndex("SalaryID");

                    b.ToTable("Advertisements", (string)null);
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1001L,
                            CityName = "تهران",
                            ProvinceId = 29
                        },
                        new
                        {
                            Id = 1002L,
                            CityName = "مشهد",
                            ProvinceId = 17
                        },
                        new
                        {
                            Id = 1003L,
                            CityName = "اصفهان",
                            ProvinceId = 13
                        },
                        new
                        {
                            Id = 1004L,
                            CityName = "شیراز",
                            ProvinceId = 7
                        },
                        new
                        {
                            Id = 1005L,
                            CityName = "تبریز",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 1006L,
                            CityName = "کرج",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 1007L,
                            CityName = "اهواز",
                            ProvinceId = 19
                        },
                        new
                        {
                            Id = 1008L,
                            CityName = "رشت",
                            ProvinceId = 8
                        },
                        new
                        {
                            Id = 1009L,
                            CityName = "کرمانشاه",
                            ProvinceId = 15
                        },
                        new
                        {
                            Id = 1010L,
                            CityName = "ارومیه",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 1011L,
                            CityName = "زنجان",
                            ProvinceId = 31
                        },
                        new
                        {
                            Id = 1012L,
                            CityName = "قزوین",
                            ProvinceId = 25
                        },
                        new
                        {
                            Id = 1013L,
                            CityName = "قم",
                            ProvinceId = 26
                        },
                        new
                        {
                            Id = 1014L,
                            CityName = "اراک",
                            ProvinceId = 23
                        },
                        new
                        {
                            Id = 1015L,
                            CityName = "ساری",
                            ProvinceId = 24
                        },
                        new
                        {
                            Id = 1016L,
                            CityName = "گرگان",
                            ProvinceId = 9
                        },
                        new
                        {
                            Id = 1017L,
                            CityName = "اردبیل",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 1018L,
                            CityName = "بندرعباس",
                            ProvinceId = 11
                        },
                        new
                        {
                            Id = 1019L,
                            CityName = "کرمان",
                            ProvinceId = 14
                        },
                        new
                        {
                            Id = 1020L,
                            CityName = "یاسوج",
                            ProvinceId = 20
                        },
                        new
                        {
                            Id = 1021L,
                            CityName = "بوشهر",
                            ProvinceId = 5
                        },
                        new
                        {
                            Id = 1022L,
                            CityName = "بجنورد",
                            ProvinceId = 16
                        },
                        new
                        {
                            Id = 1023L,
                            CityName = "بیرجند",
                            ProvinceId = 18
                        },
                        new
                        {
                            Id = 1024L,
                            CityName = "ایلام",
                            ProvinceId = 12
                        },
                        new
                        {
                            Id = 1025L,
                            CityName = "سنندج",
                            ProvinceId = 21
                        },
                        new
                        {
                            Id = 1026L,
                            CityName = "خرم‌آباد",
                            ProvinceId = 22
                        },
                        new
                        {
                            Id = 1027L,
                            CityName = "همدان",
                            ProvinceId = 10
                        },
                        new
                        {
                            Id = 1028L,
                            CityName = "ارومیه",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 1029L,
                            CityName = "سمنان",
                            ProvinceId = 27
                        },
                        new
                        {
                            Id = 1030L,
                            CityName = "زاهدان",
                            ProvinceId = 28
                        },
                        new
                        {
                            Id = 1031L,
                            CityName = "یزد",
                            ProvinceId = 30
                        },
                        new
                        {
                            Id = 1032L,
                            CityName = "قشم",
                            ProvinceId = 11
                        },
                        new
                        {
                            Id = 1033L,
                            CityName = "چابهار",
                            ProvinceId = 28
                        },
                        new
                        {
                            Id = 1034L,
                            CityName = "کیش",
                            ProvinceId = 11
                        },
                        new
                        {
                            Id = 1035L,
                            CityName = "سردشت",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 1036L,
                            CityName = "بانه",
                            ProvinceId = 21
                        },
                        new
                        {
                            Id = 1037L,
                            CityName = "بروجرد",
                            ProvinceId = 22
                        },
                        new
                        {
                            Id = 1038L,
                            CityName = "دزفول",
                            ProvinceId = 19
                        },
                        new
                        {
                            Id = 1039L,
                            CityName = "ماهشهر",
                            ProvinceId = 19
                        },
                        new
                        {
                            Id = 1040L,
                            CityName = "اندیمشک",
                            ProvinceId = 19
                        },
                        new
                        {
                            Id = 1041L,
                            CityName = "آبادان",
                            ProvinceId = 19
                        },
                        new
                        {
                            Id = 1042L,
                            CityName = "خرمشهر",
                            ProvinceId = 19
                        },
                        new
                        {
                            Id = 1043L,
                            CityName = "مهاباد",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 1044L,
                            CityName = "بوکان",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 1045L,
                            CityName = "سقز",
                            ProvinceId = 21
                        },
                        new
                        {
                            Id = 1046L,
                            CityName = "دهدشت",
                            ProvinceId = 20
                        },
                        new
                        {
                            Id = 1047L,
                            CityName = "کازرون",
                            ProvinceId = 7
                        },
                        new
                        {
                            Id = 1048L,
                            CityName = "مرودشت",
                            ProvinceId = 7
                        },
                        new
                        {
                            Id = 1049L,
                            CityName = "آمل",
                            ProvinceId = 24
                        },
                        new
                        {
                            Id = 1050L,
                            CityName = "بابل",
                            ProvinceId = 24
                        });
                });

            modelBuilder.Entity("Entities.IdentityEntities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Entities.IdentityEntities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Entities.JobCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("JobCategories", (string)null);
                });

            modelBuilder.Entity("Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ProvinceName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Provinces", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProvinceName = "البرز"
                        },
                        new
                        {
                            Id = 2,
                            ProvinceName = "اردبیل"
                        },
                        new
                        {
                            Id = 3,
                            ProvinceName = "آذربایجان شرقی"
                        },
                        new
                        {
                            Id = 4,
                            ProvinceName = "آذربایجان غربی"
                        },
                        new
                        {
                            Id = 5,
                            ProvinceName = "بوشهر"
                        },
                        new
                        {
                            Id = 6,
                            ProvinceName = "چهارمحال و بختیاری"
                        },
                        new
                        {
                            Id = 7,
                            ProvinceName = "فارس"
                        },
                        new
                        {
                            Id = 8,
                            ProvinceName = "گیلان"
                        },
                        new
                        {
                            Id = 9,
                            ProvinceName = "گلستان"
                        },
                        new
                        {
                            Id = 10,
                            ProvinceName = "همدان"
                        },
                        new
                        {
                            Id = 11,
                            ProvinceName = "هرمزگان"
                        },
                        new
                        {
                            Id = 12,
                            ProvinceName = "ایلام"
                        },
                        new
                        {
                            Id = 13,
                            ProvinceName = "اصفهان"
                        },
                        new
                        {
                            Id = 14,
                            ProvinceName = "کرمان"
                        },
                        new
                        {
                            Id = 15,
                            ProvinceName = "کرمانشاه"
                        },
                        new
                        {
                            Id = 16,
                            ProvinceName = "خراسان شمالی"
                        },
                        new
                        {
                            Id = 17,
                            ProvinceName = "خراسان رضوی"
                        },
                        new
                        {
                            Id = 18,
                            ProvinceName = "خراسان جنوبی"
                        },
                        new
                        {
                            Id = 19,
                            ProvinceName = "خوزستان"
                        },
                        new
                        {
                            Id = 20,
                            ProvinceName = "کهگیلویه و بویراحمد"
                        },
                        new
                        {
                            Id = 21,
                            ProvinceName = "کردستان"
                        },
                        new
                        {
                            Id = 22,
                            ProvinceName = "لرستان"
                        },
                        new
                        {
                            Id = 23,
                            ProvinceName = "مرکزی"
                        },
                        new
                        {
                            Id = 24,
                            ProvinceName = "مازندران"
                        },
                        new
                        {
                            Id = 25,
                            ProvinceName = "قزوین"
                        },
                        new
                        {
                            Id = 26,
                            ProvinceName = "قم"
                        },
                        new
                        {
                            Id = 27,
                            ProvinceName = "سمنان"
                        },
                        new
                        {
                            Id = 28,
                            ProvinceName = "سیستان و بلوچستان"
                        },
                        new
                        {
                            Id = 29,
                            ProvinceName = "تهران"
                        },
                        new
                        {
                            Id = 30,
                            ProvinceName = "یزد"
                        },
                        new
                        {
                            Id = 31,
                            ProvinceName = "زنجان"
                        });
                });

            modelBuilder.Entity("Entities.SalaryAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SalaryExplanation")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("SalaryAmount");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.IdentityEntities.Company", b =>
                {
                    b.HasBaseType("Entities.IdentityEntities.ApplicationUser");

                    b.Property<string>("AvatarAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyAddress")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("Entities.IdentityEntities.SiteAdministrator", b =>
                {
                    b.HasBaseType("Entities.IdentityEntities.ApplicationUser");

                    b.Property<string>("AdminName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("SiteAdministrator");
                });

            modelBuilder.Entity("Entities.Advertisement", b =>
                {
                    b.HasOne("Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Entities.IdentityEntities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Entities.JobCategory", "JobCategory")
                        .WithMany()
                        .HasForeignKey("JobCategoryId");

                    b.HasOne("Entities.SalaryAmount", "AmountOfSalary")
                        .WithMany()
                        .HasForeignKey("SalaryID");

                    b.Navigation("AmountOfSalary");

                    b.Navigation("City");

                    b.Navigation("Company");

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.HasOne("Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Entities.JobCategory", b =>
                {
                    b.HasOne("Entities.IdentityEntities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Entities.IdentityEntities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Entities.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Entities.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Entities.IdentityEntities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Entities.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}