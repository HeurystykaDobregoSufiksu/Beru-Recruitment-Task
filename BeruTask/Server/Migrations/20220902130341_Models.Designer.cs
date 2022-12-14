// <auto-generated />
using System;
using BeruTask.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeruTask.Server.Migrations
{
    [DbContext(typeof(GoldPriceContext))]
    [Migration("20220902130341_Models")]
    partial class Models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeruTask.Server.Models.GoldPriceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AvgPrice")
                        .HasColumnType("float");

                    b.Property<double>("EndPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("SaveDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("StartPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("GoldPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
