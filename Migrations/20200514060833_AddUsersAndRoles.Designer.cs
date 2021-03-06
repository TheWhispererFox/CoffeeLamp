﻿// <auto-generated />
using CoffeeLamp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeLamp.Migrations
{
    [DbContext(typeof(CoffeeContext))]
    [Migration("20200514060833_AddUsersAndRoles")]
    partial class AddUsersAndRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeLamp.Data.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleFK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login");

                    b.HasIndex("RoleFK");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoffeeLamp.Data.UserRole", b =>
                {
                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Role");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CoffeeLamp.Data.User", b =>
                {
                    b.HasOne("CoffeeLamp.Data.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
