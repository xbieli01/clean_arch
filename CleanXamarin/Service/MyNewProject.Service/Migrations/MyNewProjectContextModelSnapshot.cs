﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyNewProject.Service.Models;

namespace MyNewProject.Service.Migrations
{
    [DbContext(typeof(MyNewProjectContext))]
    partial class MyNewProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyNewProject.Domain.Orders.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeliveryMethod")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1L,
                            DeliveryMethod = 1,
                            DeliveryTime = new DateTime(2020, 4, 25, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0
                        },
                        new
                        {
                            OrderId = 2L,
                            DeliveryMethod = 1,
                            DeliveryTime = new DateTime(2020, 4, 25, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
