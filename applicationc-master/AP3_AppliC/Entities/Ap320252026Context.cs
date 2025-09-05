using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AP3_AppliC.Entities;

public partial class Ap320252026Context : DbContext
{
    public Ap320252026Context()
    {
    }

    public Ap320252026Context(DbContextOptions<Ap320252026Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Conduire> Conduires { get; set; }

    public virtual DbSet<Eleve> Eleves { get; set; }

    public virtual DbSet<Forfait> Forfaits { get; set; }

    public virtual DbSet<Inscrire> Inscrires { get; set; }

    public virtual DbSet<Moniteur> Moniteurs { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Reponse> Reponses { get; set; }

    public virtual DbSet<Resultat> Resultats { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.10.16;port=3306;user=ap3_2025_2026;password=NO0k6GX5;database=ap3_2025_2026", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Conduire>(entity =>
        {
            entity.HasKey(e => new { e.Ideleve, e.Idvehicule, e.Idmoniteur, e.Heuredebut })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity
                .ToTable("conduire")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.Ideleve, "i_fk_conduire_eleve1");

            entity.HasIndex(e => e.Idmoniteur, "i_fk_conduire_moniteur1");

            entity.HasIndex(e => e.Idvehicule, "i_fk_conduire_vehicule1");

            entity.Property(e => e.Ideleve).HasColumnName("ideleve");
            entity.Property(e => e.Idvehicule).HasColumnName("idvehicule");
            entity.Property(e => e.Idmoniteur).HasColumnName("idmoniteur");
            entity.Property(e => e.Heuredebut)
                .HasColumnType("datetime")
                .HasColumnName("heuredebut");
            entity.Property(e => e.Lieurdv)
                .HasMaxLength(128)
                .HasColumnName("lieurdv");

            entity.HasOne(d => d.IdeleveNavigation).WithMany(p => p.Conduires)
                .HasForeignKey(d => d.Ideleve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conduire_ibfk_1");

            entity.HasOne(d => d.IdmoniteurNavigation).WithMany(p => p.Conduires)
                .HasForeignKey(d => d.Idmoniteur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conduire_ibfk_3");

            entity.HasOne(d => d.IdvehiculeNavigation).WithMany(p => p.Conduires)
                .HasForeignKey(d => d.Idvehicule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conduire_ibfk_2");
        });

        modelBuilder.Entity<Eleve>(entity =>
        {
            entity.HasKey(e => e.Ideleve).HasName("PRIMARY");

            entity
                .ToTable("eleve")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Ideleve).HasColumnName("ideleve");
            entity.Property(e => e.Datenaissanceeleve).HasColumnName("datenaissanceeleve");
            entity.Property(e => e.Emaileleve)
                .HasMaxLength(255)
                .HasColumnName("emaileleve");
            entity.Property(e => e.Motpasseeleve)
                .HasMaxLength(255)
                .HasColumnName("motpasseeleve");
            entity.Property(e => e.Nomeleve)
                .HasMaxLength(128)
                .HasColumnName("nomeleve");
            entity.Property(e => e.Prenomeleve)
                .HasMaxLength(128)
                .HasColumnName("prenomeleve");
        });

        modelBuilder.Entity<Forfait>(entity =>
        {
            entity.HasKey(e => e.Idforfait).HasName("PRIMARY");

            entity
                .ToTable("forfait")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Idforfait).HasColumnName("idforfait");
            entity.Property(e => e.Contenuforfait)
                .HasColumnType("text")
                .HasColumnName("contenuforfait");
            entity.Property(e => e.Descriptionforfait)
                .HasColumnType("text")
                .HasColumnName("descriptionforfait");
            entity.Property(e => e.Libelleforfait)
                .HasMaxLength(255)
                .HasColumnName("libelleforfait");
            entity.Property(e => e.Nbheures).HasColumnName("nbheures");
            entity.Property(e => e.Prixforfait)
                .HasPrecision(10, 2)
                .HasColumnName("prixforfait");
            entity.Property(e => e.Prixhoraire)
                .HasPrecision(10, 2)
                .HasColumnName("prixhoraire");
        });

        modelBuilder.Entity<Inscrire>(entity =>
        {
            entity.HasKey(e => new { e.Ideleve, e.Idforfait, e.Dateinscription })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity
                .ToTable("inscrire")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.Ideleve, "i_fk_inscrire_eleve1");

            entity.HasIndex(e => e.Idforfait, "i_fk_inscrire_forfait1");

            entity.Property(e => e.Ideleve).HasColumnName("ideleve");
            entity.Property(e => e.Idforfait).HasColumnName("idforfait");
            entity.Property(e => e.Dateinscription).HasColumnName("dateinscription");

            entity.HasOne(d => d.IdeleveNavigation).WithMany(p => p.Inscrires)
                .HasForeignKey(d => d.Ideleve)
                .HasConstraintName("inscrire_ibfk_1");

            entity.HasOne(d => d.IdforfaitNavigation).WithMany(p => p.Inscrires)
                .HasForeignKey(d => d.Idforfait)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscrire_ibfk_2");
        });

        modelBuilder.Entity<Moniteur>(entity =>
        {
            entity.HasKey(e => e.Idmoniteur).HasName("PRIMARY");

            entity
                .ToTable("moniteur")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Idmoniteur).HasColumnName("idmoniteur");
            entity.Property(e => e.Emailmoniteur)
                .HasMaxLength(255)
                .HasColumnName("emailmoniteur");
            entity.Property(e => e.Nommoniteur)
                .HasMaxLength(128)
                .HasColumnName("nommoniteur");
            entity.Property(e => e.Prenommoniteur)
                .HasMaxLength(128)
                .HasColumnName("prenommoniteur");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Idquestion).HasName("PRIMARY");

            entity
                .ToTable("question")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Idquestion).HasColumnName("idquestion");
            entity.Property(e => e.Imagequestion)
                .HasMaxLength(255)
                .HasColumnName("imagequestion");
            entity.Property(e => e.Libellequestion)
                .HasMaxLength(255)
                .HasColumnName("libellequestion");
        });

        modelBuilder.Entity<Reponse>(entity =>
        {
            entity.HasKey(e => new { e.Idquestion, e.Numreponse })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("reponse")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.Idquestion, "i_fk_reponse_question1");

            entity.Property(e => e.Idquestion).HasColumnName("idquestion");
            entity.Property(e => e.Numreponse).HasColumnName("numreponse");
            entity.Property(e => e.Libellereponse)
                .HasMaxLength(255)
                .HasColumnName("libellereponse");
            entity.Property(e => e.Valide)
                .HasDefaultValueSql("'0'")
                .HasColumnName("valide");

            entity.HasOne(d => d.IdquestionNavigation).WithMany(p => p.Reponses)
                .HasForeignKey(d => d.Idquestion)
                .HasConstraintName("reponse_ibfk_1");
        });

        modelBuilder.Entity<Resultat>(entity =>
        {
            entity.HasKey(e => e.Idresultat).HasName("PRIMARY");

            entity
                .ToTable("resultat")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.Ideleve, "i_fk_resultat_eleve1");

            entity.Property(e => e.Idresultat).HasColumnName("idresultat");
            entity.Property(e => e.Dateresultat)
                .HasColumnType("datetime")
                .HasColumnName("dateresultat");
            entity.Property(e => e.Ideleve).HasColumnName("ideleve");
            entity.Property(e => e.Nbquestions).HasColumnName("nbquestions");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.IdeleveNavigation).WithMany(p => p.Resultats)
                .HasForeignKey(d => d.Ideleve)
                .HasConstraintName("resultat_ibfk_1");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Token1).HasName("PRIMARY");

            entity.ToTable("token");

            entity.HasIndex(e => e.Token1, "token").IsUnique();

            entity.HasIndex(e => e.Ideleve, "token_ibfk_1");

            entity.Property(e => e.Token1).HasColumnName("token");
            entity.Property(e => e.DateCreation)
                .HasColumnType("datetime")
                .HasColumnName("date_creation");
            entity.Property(e => e.Ideleve).HasColumnName("ideleve");

            entity.HasOne(d => d.IdeleveNavigation).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.Ideleve)
                .HasConstraintName("token_ibfk_1");
        });

        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.HasKey(e => e.Idvehicule).HasName("PRIMARY");

            entity
                .ToTable("vehicule")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Idvehicule).HasColumnName("idvehicule");
            entity.Property(e => e.Designation)
                .HasMaxLength(128)
                .HasColumnName("designation");
            entity.Property(e => e.Immatriculation)
                .HasMaxLength(128)
                .HasColumnName("immatriculation");
            entity.Property(e => e.Manuel)
                .HasDefaultValueSql("'1'")
                .HasColumnName("manuel");
            entity.Property(e => e.Nbpassagers).HasColumnName("nbpassagers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
