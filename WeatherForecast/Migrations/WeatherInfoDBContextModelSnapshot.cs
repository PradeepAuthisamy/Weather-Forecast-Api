﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecast.DataAccess;

namespace WeatherForecast.Migrations
{
    [DbContext(typeof(WeatherInfoDBContext))]
    partial class WeatherInfoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherForecast.Models.DeviceInfo", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DeviceID")
                        .HasColumnType("int");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Firmware")
                        .HasColumnType("float");

                    b.Property<double?>("Hardware")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("WeatherForecast.Models.Rain7Dayinfo", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("RainInfo");
                });

            modelBuilder.Entity("WeatherForecast.Models.Rain7Dayinfo", b =>
                {
                    b.HasOne("WeatherForecast.Models.DeviceInfo", "DeviceInfo")
                        .WithOne("Rain7DayInfo")
                        .HasForeignKey("WeatherForecast.Models.Rain7Dayinfo", "Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceInfo");
                });

            modelBuilder.Entity("WeatherForecast.Models.DeviceInfo", b =>
                {
                    b.Navigation("Rain7DayInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
