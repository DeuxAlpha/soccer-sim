﻿// <auto-generated />
using System;
using Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(SoccerSimContext))]
    [Migration("20200730232119_FixDefaultProgressChanceValues")]
    partial class FixDefaultProgressChanceValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Models.Continent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Name", "Season");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("Database.Models.Country", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<double>("AttackStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<string>("ContinentName")
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

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Name", "Season");

                    b.HasIndex("ContinentName", "Season");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Database.Models.Division", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Name", "Season");

                    b.HasIndex("CountryName", "Season");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Database.Models.League", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("ActionsPerMinute")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(4);

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxAwayDisadvantage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("MaxHomeAdvantage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("MaxProgressChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.69999999999999996);

                    b.Property<double>("MinProgressChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.29999999999999999);

                    b.Property<double>("PaceModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.Property<double>("ShotAccuracyModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.HasKey("Name", "Season");

                    b.HasIndex("DivisionName", "Season");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Database.Models.LeagueFixture", b =>
                {
                    b.Property<string>("LeagueName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("GameDayNumber")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeamName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("AwayTeamName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("ActionsPerMinute")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(4);

                    b.Property<int?>("AwayPossession")
                        .HasColumnType("int");

                    b.Property<int>("HalfFieldLength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(100);

                    b.Property<int?>("HomePossession")
                        .HasColumnType("int");

                    b.Property<double>("MaxAwayDisadvantage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("MaxHomeAdvantage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<int>("MaxOvertime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(8);

                    b.Property<double>("PaceModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.Property<double>("ShotAccuracyModifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.HasKey("LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName");

                    b.HasIndex("AwayTeamName", "Season");

                    b.HasIndex("HomeTeamName", "Season");

                    b.ToTable("LeagueFixtures");
                });

            modelBuilder.Entity("Database.Models.LeagueFixtureEvent", b =>
                {
                    b.Property<string>("LeagueName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("GameDayNumber")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeamName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("AwayTeamName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("AddedMinute")
                        .HasColumnType("int");

                    b.Property<string>("EventTeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsGoal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShotOnGoal")
                        .HasColumnType("bit");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.HasKey("LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName");

                    b.HasIndex("EventTeamName", "Season");

                    b.ToTable("LeagueFixtureEvents");
                });

            modelBuilder.Entity("Database.Models.LeagueGameDay", b =>
                {
                    b.Property<string>("LeagueName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("GameDayNumber")
                        .HasColumnType("int");

                    b.HasKey("LeagueName", "Season", "GameDayNumber");

                    b.ToTable("LeagueGameDays");
                });

            modelBuilder.Entity("Database.Models.Team", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Season")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<double>("AttackStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<double>("DefenseStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<double>("GoalieStrength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(600.0);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeagueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaxPace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(40);

                    b.Property<double>("PotentialNegativeChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PotentialNegativeShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PotentialPositiveChance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PotentialPositiveShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<double>("ShotOnGoalRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.40000000000000002);

                    b.HasKey("Name", "Season");

                    b.HasIndex("LeagueName", "Season");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Database.Models.Country", b =>
                {
                    b.HasOne("Database.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Division", b =>
                {
                    b.HasOne("Database.Models.Country", "Country")
                        .WithMany("Divisions")
                        .HasForeignKey("CountryName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.League", b =>
                {
                    b.HasOne("Database.Models.Division", "Division")
                        .WithMany("Leagues")
                        .HasForeignKey("DivisionName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.LeagueFixture", b =>
                {
                    b.HasOne("Database.Models.Team", "AwayTeam")
                        .WithMany("AwayLeagueFixtures")
                        .HasForeignKey("AwayTeamName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Models.Team", "HomeTeam")
                        .WithMany("HomeLeagueFixtures")
                        .HasForeignKey("HomeTeamName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Models.League", "League")
                        .WithMany("LeagueFixtures")
                        .HasForeignKey("LeagueName", "Season")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.LeagueGameDay", "GameDay")
                        .WithMany("Fixtures")
                        .HasForeignKey("LeagueName", "Season", "GameDayNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.LeagueFixtureEvent", b =>
                {
                    b.HasOne("Database.Models.Team", "EventTeam")
                        .WithMany("LeagueFixtureEvents")
                        .HasForeignKey("EventTeamName", "Season")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.LeagueFixture", "LeagueFixture")
                        .WithMany("Events")
                        .HasForeignKey("LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.LeagueGameDay", b =>
                {
                    b.HasOne("Database.Models.League", "League")
                        .WithMany("GameDays")
                        .HasForeignKey("LeagueName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Team", b =>
                {
                    b.HasOne("Database.Models.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueName", "Season")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
