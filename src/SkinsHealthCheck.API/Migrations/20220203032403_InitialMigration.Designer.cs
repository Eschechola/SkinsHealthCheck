﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkinsApiHealthChecks.Api.Context;

#nullable disable

namespace SkinsApiHealthChecks.Api.Migrations
{
    [DbContext(typeof(SkinContext))]
    [Migration("20220203032403_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkinsApiHealthChecksApi.Models.Skin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Float")
                        .HasColumnType("DOUBLE")
                        .HasColumnName("Float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("Name");

                    b.Property<int>("Pattern")
                        .HasColumnType("INT")
                        .HasColumnName("Pattern");

                    b.HasKey("Id");

                    b.ToTable("Skin", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
