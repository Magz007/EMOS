﻿// <auto-generated />
using System;
using EMOS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMOS.Migrations
{
    [DbContext(typeof(EMOSContext))]
    partial class EMOSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMOS.Models.Employees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Contractedhours");

                    b.Property<string>("DBSchecked");

                    b.Property<DateTime>("DBSrenewaldate");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Department");

                    b.Property<string>("Email");

                    b.Property<string>("Fname");

                    b.Property<string>("Jobrole");

                    b.Property<int>("Ninumber");

                    b.Property<int>("Phone");

                    b.Property<string>("Surname");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EMOS.Models.RCH", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Companyname");

                    b.Property<string>("County");

                    b.Property<string>("Flineaddress");

                    b.Property<int>("Phonenumber");

                    b.Property<string>("Postcode");

                    b.HasKey("ID");

                    b.ToTable("RCH");
                });

            modelBuilder.Entity("EMOS.Models.Resident", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FnameInital");

                    b.Property<int>("Roomnumber");

                    b.Property<string>("Surname");

                    b.HasKey("ID");

                    b.ToTable("Resident");
                });
#pragma warning restore 612, 618
        }
    }
}
