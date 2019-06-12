﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SafaricomHackathonQ2.Data;

namespace SafaricomHackathonQ2.Data.Migrations
{
    [DbContext(typeof(SafaricomContext))]
    [Migration("20190612081804_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SafaricomHackathonQ2.Data.Models.CreditVoucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<string>("SerialNumber");

                    b.Property<Guid?>("UserId");

                    b.Property<Guid>("VendorId");

                    b.Property<string>("VoucherNumber");

                    b.Property<int>("VoucherStatus");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VendorId");

                    b.ToTable("CreditVouchers");
                });

            modelBuilder.Entity("SafaricomHackathonQ2.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balamce");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SafaricomHackathonQ2.Data.Models.Vendor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<double>("Balance");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("SafaricomHackathonQ2.Data.Models.CreditVoucher", b =>
                {
                    b.HasOne("SafaricomHackathonQ2.Data.Models.User", "User")
                        .WithMany("CreditVouchers")
                        .HasForeignKey("UserId");

                    b.HasOne("SafaricomHackathonQ2.Data.Models.Vendor", "Vendor")
                        .WithMany("CreditVouchers")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
