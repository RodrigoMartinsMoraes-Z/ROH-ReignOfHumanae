﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ROH.Context.PostgreSQLContext;

#nullable disable

namespace ROH.Context.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ROH.Domain.Accounts.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<string>("RealName")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ROH.Domain.Accounts.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<long>("IdAccount")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ROH.Domain.Characters.AttackStatus", b =>
                {
                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("LongRangedWeaponLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("MagicWeaponLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("OneHandedWeaponLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("TwoHandedWeaponLevel")
                        .HasColumnType("bigint");

                    b.HasKey("IdCharacter");

                    b.ToTable("AttackStatuses");
                });

            modelBuilder.Entity("ROH.Domain.Characters.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<long>("IdAccount")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdGuild")
                        .HasColumnType("bigint");

                    b.Property<long>("IdKingdom")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Race")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdGuild");

                    b.HasIndex("IdKingdom");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ROH.Domain.Characters.CharacterInventory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("IdItem")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdCharacter");

                    b.HasIndex("IdItem");

                    b.ToTable("CharacterInventory");
                });

            modelBuilder.Entity("ROH.Domain.Characters.CharacterSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("IdSkill")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdCharacter");

                    b.HasIndex("IdSkill");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("ROH.Domain.Characters.DefenseStatus", b =>
                {
                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("ArcaneDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("DarknessDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("EarthDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("FireDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("LightDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("LightningDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("MagicDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("PhysicDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("WaterDefenseLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("WindDefenseLevel")
                        .HasColumnType("bigint");

                    b.HasKey("IdCharacter");

                    b.ToTable("DefenseStatuses");
                });

            modelBuilder.Entity("ROH.Domain.Characters.EquippedItems", b =>
                {
                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdArmor")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdBoots")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdGloves")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdHead")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdLeftBracelet")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdLegs")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdNecklace")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdRightBracelet")
                        .HasColumnType("bigint");

                    b.HasKey("IdCharacter");

                    b.HasIndex("IdArmor");

                    b.HasIndex("IdBoots");

                    b.HasIndex("IdGloves");

                    b.HasIndex("IdHead");

                    b.HasIndex("IdLeftBracelet");

                    b.HasIndex("IdLegs");

                    b.HasIndex("IdNecklace");

                    b.HasIndex("IdRightBracelet");

                    b.ToTable("EquippedItems");
                });

            modelBuilder.Entity("ROH.Domain.Characters.HandRing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdEquippedItems")
                        .HasColumnType("bigint");

                    b.Property<long>("IdItem")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdEquippedItems");

                    b.HasIndex("IdItem");

                    b.ToTable("RingsEquipped");
                });

            modelBuilder.Entity("ROH.Domain.Characters.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Animation")
                        .HasColumnType("text");

                    b.Property<long?>("Damage")
                        .HasColumnType("bigint");

                    b.Property<long?>("Defense")
                        .HasColumnType("bigint");

                    b.Property<long>("ManaCost")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ROH.Domain.Characters.Status", b =>
                {
                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrentCarryWeight")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrentHealth")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrentMana")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrentStamina")
                        .HasColumnType("bigint");

                    b.Property<long>("FullCarryWeight")
                        .HasColumnType("bigint");

                    b.Property<long>("FullHealth")
                        .HasColumnType("bigint");

                    b.Property<long>("FullMana")
                        .HasColumnType("bigint");

                    b.Property<long>("FullStamina")
                        .HasColumnType("bigint");

                    b.Property<long>("Level")
                        .HasColumnType("bigint");

                    b.Property<long>("MagicLevel")
                        .HasColumnType("bigint");

                    b.HasKey("IdCharacter");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ROH.Domain.Guilds.Guild", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("ROH.Domain.Guilds.MembersPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("IdGuild")
                        .HasColumnType("bigint");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdCharacter")
                        .IsUnique();

                    b.HasIndex("IdGuild");

                    b.ToTable("MembersPositions");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.Champion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCharacter")
                        .HasColumnType("bigint");

                    b.Property<long>("IdKingdom")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdCharacter");

                    b.HasIndex("IdKingdom");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.Kingdom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdRuler")
                        .HasColumnType("bigint");

                    b.Property<int>("Reign")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdRuler")
                        .IsUnique();

                    b.ToTable("Kingdoms");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.KingdomRelation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdKingdom")
                        .HasColumnType("bigint");

                    b.Property<long>("IdKingdom2")
                        .HasColumnType("bigint");

                    b.Property<int>("Situation")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdKingdom2");

                    b.ToTable("KingdomRelations");
                });

            modelBuilder.Entity("ROH.Domain.Version.GameVersion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("Release")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Released")
                        .HasColumnType("boolean");

                    b.Property<int>("Review")
                        .HasColumnType("integer");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("VersionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("GameVersions");
                });

            modelBuilder.Entity("ROH.Domain.Version.GameVersionFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<long>("IdVersion")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdVersion");

                    b.ToTable("GameVersionFiles");
                });

            modelBuilder.Entity("ROH.Domain.items.Enchantment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Animation")
                        .HasColumnType("text");

                    b.Property<long?>("Damage")
                        .HasColumnType("bigint");

                    b.Property<long?>("Defense")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Enchantments");
                });

            modelBuilder.Entity("ROH.Domain.items.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("Attack")
                        .HasColumnType("integer");

                    b.Property<int?>("Defense")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("File")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Sprite")
                        .HasColumnType("text");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ROH.Domain.items.ItemEnchantment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdEnchantment")
                        .HasColumnType("bigint");

                    b.Property<long>("IdItem")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdEnchantment");

                    b.HasIndex("IdItem");

                    b.ToTable("ItemEnchantments");
                });

            modelBuilder.Entity("ROH.Domain.Accounts.User", b =>
                {
                    b.HasOne("ROH.Domain.Accounts.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("ROH.Domain.Accounts.User", "IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ROH.Domain.Characters.AttackStatus", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithOne("AttackStatus")
                        .HasForeignKey("ROH.Domain.Characters.AttackStatus", "IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ROH.Domain.Characters.Character", b =>
                {
                    b.HasOne("ROH.Domain.Accounts.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.Guilds.Guild", "Guild")
                        .WithMany("Characters")
                        .HasForeignKey("IdGuild");

                    b.HasOne("ROH.Domain.Kingdoms.Kingdom", "Kingdom")
                        .WithMany("Citizens")
                        .HasForeignKey("IdKingdom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Guild");

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("ROH.Domain.Characters.CharacterInventory", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithMany("Inventory")
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.items.Item", "Item")
                        .WithMany()
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ROH.Domain.Characters.CharacterSkill", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.Characters.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("IdSkill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("ROH.Domain.Characters.DefenseStatus", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithOne("DefenseStatus")
                        .HasForeignKey("ROH.Domain.Characters.DefenseStatus", "IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ROH.Domain.Characters.EquippedItems", b =>
                {
                    b.HasOne("ROH.Domain.items.Item", "Armor")
                        .WithMany()
                        .HasForeignKey("IdArmor");

                    b.HasOne("ROH.Domain.items.Item", "Boots")
                        .WithMany()
                        .HasForeignKey("IdBoots");

                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithOne("EquippedItems")
                        .HasForeignKey("ROH.Domain.Characters.EquippedItems", "IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.items.Item", "Gloves")
                        .WithMany()
                        .HasForeignKey("IdGloves");

                    b.HasOne("ROH.Domain.items.Item", "Head")
                        .WithMany()
                        .HasForeignKey("IdHead");

                    b.HasOne("ROH.Domain.items.Item", "LeftBracelet")
                        .WithMany()
                        .HasForeignKey("IdLeftBracelet");

                    b.HasOne("ROH.Domain.items.Item", "Legs")
                        .WithMany()
                        .HasForeignKey("IdLegs");

                    b.HasOne("ROH.Domain.items.Item", "Necklace")
                        .WithMany()
                        .HasForeignKey("IdNecklace");

                    b.HasOne("ROH.Domain.items.Item", "RightBracelet")
                        .WithMany()
                        .HasForeignKey("IdRightBracelet");

                    b.Navigation("Armor");

                    b.Navigation("Boots");

                    b.Navigation("Character");

                    b.Navigation("Gloves");

                    b.Navigation("Head");

                    b.Navigation("LeftBracelet");

                    b.Navigation("Legs");

                    b.Navigation("Necklace");

                    b.Navigation("RightBracelet");
                });

            modelBuilder.Entity("ROH.Domain.Characters.HandRing", b =>
                {
                    b.HasOne("ROH.Domain.Characters.EquippedItems", "EquippedItems")
                        .WithMany("RightHandRings")
                        .HasForeignKey("IdEquippedItems")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.items.Item", "Item")
                        .WithMany()
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquippedItems");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ROH.Domain.Characters.Status", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithOne("Status")
                        .HasForeignKey("ROH.Domain.Characters.Status", "IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ROH.Domain.Guilds.MembersPosition", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithOne()
                        .HasForeignKey("ROH.Domain.Guilds.MembersPosition", "IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.Guilds.Guild", "Guild")
                        .WithMany("MembersPositions")
                        .HasForeignKey("IdGuild")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.Champion", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Character")
                        .WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.Kingdoms.Kingdom", "Kingdom")
                        .WithMany("Champions")
                        .HasForeignKey("IdKingdom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.Kingdom", b =>
                {
                    b.HasOne("ROH.Domain.Characters.Character", "Ruler")
                        .WithOne()
                        .HasForeignKey("ROH.Domain.Kingdoms.Kingdom", "IdRuler")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruler");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.KingdomRelation", b =>
                {
                    b.HasOne("ROH.Domain.Kingdoms.Kingdom", "Kingdom2")
                        .WithMany("KingdomRelations")
                        .HasForeignKey("IdKingdom2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom2");
                });

            modelBuilder.Entity("ROH.Domain.Version.GameVersionFile", b =>
                {
                    b.HasOne("ROH.Domain.Version.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("IdVersion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameVersion");
                });

            modelBuilder.Entity("ROH.Domain.items.ItemEnchantment", b =>
                {
                    b.HasOne("ROH.Domain.items.Enchantment", "Enchantment")
                        .WithMany("Items")
                        .HasForeignKey("IdEnchantment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROH.Domain.items.Item", "Item")
                        .WithMany("Enchantments")
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enchantment");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ROH.Domain.Accounts.Account", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ROH.Domain.Characters.Character", b =>
                {
                    b.Navigation("AttackStatus");

                    b.Navigation("DefenseStatus");

                    b.Navigation("EquippedItems");

                    b.Navigation("Inventory");

                    b.Navigation("Skills");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ROH.Domain.Characters.EquippedItems", b =>
                {
                    b.Navigation("RightHandRings");
                });

            modelBuilder.Entity("ROH.Domain.Guilds.Guild", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("MembersPositions");
                });

            modelBuilder.Entity("ROH.Domain.Kingdoms.Kingdom", b =>
                {
                    b.Navigation("Champions");

                    b.Navigation("Citizens");

                    b.Navigation("KingdomRelations");
                });

            modelBuilder.Entity("ROH.Domain.items.Enchantment", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ROH.Domain.items.Item", b =>
                {
                    b.Navigation("Enchantments");
                });
#pragma warning restore 612, 618
        }
    }
}
