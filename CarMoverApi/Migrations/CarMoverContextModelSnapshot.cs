using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CarMoverApi.Models;

namespace CarMoverApi.Migrations
{
    [DbContext(typeof(CarMoverContext))]
    partial class CarMoverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarMoverApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Plate");

                    b.Property<long?>("UserFaceBookUserId");

                    b.HasKey("Id");

                    b.HasIndex("UserFaceBookUserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarMoverApi.Models.User", b =>
                {
                    b.Property<long>("FaceBookUserId");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name");

                    b.HasKey("FaceBookUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarMoverApi.Models.Car", b =>
                {
                    b.HasOne("CarMoverApi.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserFaceBookUserId");
                });
        }
    }
}
