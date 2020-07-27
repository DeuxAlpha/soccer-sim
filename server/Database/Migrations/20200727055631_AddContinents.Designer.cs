﻿// <auto-generated />
using Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(SoccerSimContext))]
    [Migration("20200727055631_AddContinents")]
    partial class AddContinents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Models.Competition", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CompetitionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ContinentName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("MaxAwayDisadvantage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("MaxHomeAdvantage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PaceModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.Property<double>("ShotAccuracyModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.HasKey("Name", "Year");

                    b.HasIndex("ContinentName", "Year");

                    b.HasIndex("CountryName", "Year");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Database.Models.Continent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Name", "Year");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("Database.Models.Country", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<double>("AttackStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<double>("CountryStrengthModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.Property<double>("DefenseStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<double>("GoalieStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<int>("MaxPace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(40);

                    b.Property<double>("PotentialNegativeChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.10000000000000001);

                    b.Property<double>("PotentialNegativeShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<double>("PotentialPositiveChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.10000000000000001);

                    b.Property<double>("PotentialPositiveShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<double>("ShotOnGoalRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.40000000000000002);

                    b.HasKey("Name", "Year");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Database.Models.Team", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<double>("AttackStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("DefenseStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<double>("GoalieStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<int>("MaxPace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(40);

                    b.Property<double>("PotentialNegativeChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.10000000000000001);

                    b.Property<double>("PotentialNegativeShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<double>("PotentialPositiveChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.10000000000000001);

                    b.Property<double>("PotentialPositiveShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<double>("ShotOnGoalRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.40000000000000002);

                    b.HasKey("Name", "Year");

                    b.HasIndex("CountryName", "Year");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Database.Models.TeamCompetition", b =>
                {
                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("CompetitionName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Year", "TeamName", "CompetitionName");

                    b.HasIndex("CompetitionName", "Year");

                    b.HasIndex("TeamName", "Year");

                    b.ToTable("TeamCompetitions");
                });

            modelBuilder.Entity("Database.Models.Competition", b =>
                {
                    b.HasOne("Database.Models.Continent", "Continent")
                        .WithMany("Competitions")
                        .HasForeignKey("ContinentName", "Year")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Database.Models.Country", "Country")
                        .WithMany("Competitions")
                        .HasForeignKey("CountryName", "Year")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Database.Models.Team", b =>
                {
                    b.HasOne("Database.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryName", "Year")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.TeamCompetition", b =>
                {
                    b.HasOne("Database.Models.Competition", "Competition")
                        .WithMany("Teams")
                        .HasForeignKey("CompetitionName", "Year")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Models.Team", "Team")
                        .WithMany("Competitions")
                        .HasForeignKey("TeamName", "Year")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
