﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SDATA;

namespace SDATA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200614015716_SeedValues")]
    partial class SeedValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SDomain.Value", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Value 101"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Value 102"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Value 103"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Value 104"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Value 105"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
