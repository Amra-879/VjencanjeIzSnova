using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VjencanjeIzSnova_July.Models;

namespace VjencanjeIzSnova_July.Data;

public partial class VjencanjeIzSnovaDbContext : IdentityDbContext<Korisnici>
{
    private readonly IConfiguration _configuration;

    public VjencanjeIzSnovaDbContext(DbContextOptions<VjencanjeIzSnovaDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("VjencanjeIzSnovaDB");
            optionsBuilder.UseSqlite(connectionString);
        }
    }

    public virtual DbSet<Kategorije> Kategorije { get; set; }

    public virtual DbSet<Klijent> Klijenti { get; set; }

    public virtual DbSet<Korisnici> Korisnici { get; set; }

    public virtual DbSet<Košarica> Košarica { get; set; }

    public virtual DbSet<Partner> Partneri { get; set; }

    public virtual DbSet<Planer> Planeri { get; set; }

    public virtual DbSet<Plaćanja> Plaćanja { get; set; }

    public virtual DbSet<Recenzije> Recenzije { get; set; }

    public virtual DbSet<Rezervacije> Rezervacije { get; set; }

    public virtual DbSet<Usluge> Usluge { get; set; }

    public virtual DbSet<Slike> Slike { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kategorije>(entity =>
        {
            entity.HasKey(e => e.KategorijaId).HasName("PK__Kategori__487607FB19F75645");

            entity.ToTable("Kategorije");

            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .HasColumnName("naziv");
            entity.Property(e => e.Opis).HasColumnName("opis");
        });

        modelBuilder.Entity<Klijent>(entity =>
        {
            entity.HasKey(e => e.KlijentId).HasName("PK__Klijent__9D7F1ACABE38AB79");

            entity.ToTable("Klijent");

            entity.HasIndex(e => e.UserId, "UQ__Klijent__B9BE370E02949A1F").IsUnique();

            entity.Property(e => e.KlijentId).HasColumnName("klijent_id");
            entity.Property(e => e.DatumVjenčanja).HasColumnName("datum_vjenčanja");
            entity.Property(e => e.Grad)
                .HasMaxLength(50)
                .HasColumnName("grad");
            entity.Property(e => e.Ime)
                .HasMaxLength(100)
                .HasColumnName("ime");
            entity.Property(e => e.Prezime)
                .HasMaxLength(100)
                .HasColumnName("prezime");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Klijent)
                .HasForeignKey<Klijent>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Klijent__user_id__3B75D760");
        });

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Korisnic__B9BE370F03FE7D68");

            entity.ToTable("Korisnici");

            entity.HasIndex(e => e.Email, "UQ__Korisnic__AB6E6164532F21D4").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .HasColumnName("user_type");
            entity.Property(e => e.ProfilnaSlikaUrl)
                .HasColumnType("TEXT")
                .HasColumnName("ProfilnaSlikaUrl");
        });

        modelBuilder.Entity<Košarica>(entity =>
        {
            entity.HasKey(e => e.KošaricaId).HasName("PK__Košarica__4C4EEBFCF74FD176");

            entity.ToTable("Košarica");

            entity.Property(e => e.KošaricaId).HasColumnName("košarica_id");
            entity.Property(e => e.Cijena)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cijena");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.NazivArtikla)
                .HasMaxLength(100)
                .HasColumnName("naziv_artikla");

            entity.HasOne(d => d.Client).WithMany(p => p.Košarica)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Košarica__client__5812160E");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("PK__Partner__576F1B27720B1D72");

            entity.ToTable("Partner");

            entity.HasIndex(e => e.UserId, "UQ__Partner__B9BE370ECFCA0A5E").IsUnique();

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Ime)
                .HasMaxLength(100)
                .HasColumnName("ime");
            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.Mobitel)
                .HasMaxLength(15)
                .HasColumnName("mobitel");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Partners)
                .HasForeignKey(d => d.KategorijaId)
                .HasConstraintName("FK__Partner__kategor__4222D4EF");

            entity.HasOne(d => d.User).WithOne(p => p.Partner)
                .HasForeignKey<Partner>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Partner__user_id__412EB0B6");
        });

        modelBuilder.Entity<Planer>(entity =>
        {
            entity.HasKey(e => e.PlanerId).HasName("PK__Planer__BF194A6C68A607B5");

            entity.ToTable("Planer");

            entity.HasIndex(e => e.UserId, "UQ__Planer__B9BE370EEF0010D4").IsUnique();

            entity.Property(e => e.PlanerId).HasColumnName("planer_id");
            entity.Property(e => e.BrTrenutnihKlijenata).HasColumnName("br_trenutnih_klijenata");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ZoomMeetingLink)
                .HasMaxLength(100)
                .HasColumnName("zoom_meeting_link");

            entity.HasOne(d => d.User).WithOne(p => p.Planer)
                .HasForeignKey<Planer>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Planer__user_id__45F365D3");

            entity.HasMany(d => d.Clients).WithMany(p => p.Planer)
                .UsingEntity<Dictionary<string, object>>(
                    "PlanerKlijenti",
                    r => r.HasOne<Klijent>().WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PlanerKli__clien__5BE2A6F2"),
                    l => l.HasOne<Planer>().WithMany()
                        .HasForeignKey("PlanerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PlanerKli__plane__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("PlanerId", "ClientId").HasName("PK__PlanerKl__E4EB502E5A1C619D");
                        j.ToTable("PlanerKlijenti");
                        j.IndexerProperty<int>("PlanerId").HasColumnName("planer_id");
                        j.IndexerProperty<int>("ClientId").HasColumnName("client_id");
                    });
        });

        modelBuilder.Entity<Plaćanja>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Plaćanja__ED1FC9EA615C8B2E");

            entity.ToTable("Plaćanja");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Iznos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iznos");
            entity.Property(e => e.PlacanjeDatum)
                .HasColumnType("datetime")
                .HasColumnName("placanje_datum");
            entity.Property(e => e.TransakcijaId)
                .HasMaxLength(100)
                .HasColumnName("transakcija_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Plaćanja)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Plaćanja__client__5535A963");
        });

        modelBuilder.Entity<Recenzije>(entity =>
        {
            entity.HasKey(e => e.RecenzijaId).HasName("PK__Recenzij__020681BA242E6DDA");

            entity.ToTable("Recenzije");

            entity.Property(e => e.RecenzijaId).HasColumnName("recenzija_id");
            entity.Property(e => e.KlijentId).HasColumnName("klijent_id");
            entity.Property(e => e.Datum).HasColumnName("datum");
            entity.Property(e => e.Komentar).HasColumnName("komentar");
            entity.Property(e => e.Ocjena).HasColumnName("ocjena");
            entity.Property(e => e.UslugaId).HasColumnName("partner_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Recenzije)
                .HasForeignKey(d => d.KlijentId)
                .HasConstraintName("FK__Recenzije__klijent__5165187F");

            entity.HasOne(d => d.Partner).WithMany(p => p.Recenzija)
                .HasForeignKey(d => d.UslugaId)
                .HasConstraintName("FK__Recenzije__usluga__52593CB8");
        });

        modelBuilder.Entity<Rezervacije>(entity =>
        {
            entity.HasKey(e => e.RezervacijeId).HasName("PK__Rezervac__4F18667E0FB39479");

            entity.ToTable("Rezervacije");

            entity.Property(e => e.RezervacijeId).HasColumnName("rezervacije_id");
            entity.Property(e => e.ClientId).HasColumnName("klijent_id");
            entity.Property(e => e.Datum).HasColumnName("datum");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.UslugaId).HasColumnName("usluga_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Rezervacije)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Rezervacije__klijent__4CA06362");

            entity.HasOne(d => d.Usluga)
                  .WithMany(p => p.Rezervacije)
                  .HasForeignKey(d => d.UslugaId)
                  .HasConstraintName("FK__Rezervacije__usluga__4D94879B");
        });

        modelBuilder.Entity<Usluge>(entity =>
        {
            entity.HasKey(e => e.UslugaId).HasName("PK__Usluge__188C4FFA9282855A");

            entity.ToTable("Usluge");

            entity.Property(e => e.UslugaId).HasColumnName("usluga_id");
            entity.Property(e => e.CjenovniRang)
                .HasMaxLength(100)
                .HasColumnName("cjenovniRang");
            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .HasColumnName("naziv");
            entity.Property(e => e.OpisUsluge).HasColumnName("opis");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.InfoOKompaniji).HasColumnName("infoOKompaniji");
            entity.Property(e => e.Detalji).HasColumnName("detalji");

            entity.HasOne(d => d.Partner)
                .WithMany(p => p.Usluga)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Usluge__partner___48CFD27E");

            entity.HasMany(d => d.Slike)
                .WithOne(p => p.Usluga)
                .HasForeignKey(p => p.UslugaId)
                .OnDelete(DeleteBehavior.Cascade) 
                .HasConstraintName("FK__Slike__usluga_id");
        });

        modelBuilder.Entity<Slike>(entity =>
        {
            entity.HasKey(e => e.Url).HasName("PK__Slike__5B5B1F5A0E5504C4");

            entity.ToTable("Slike");

            entity.Property(e => e.Url)
                .HasColumnType("TEXT")
                .HasColumnName("Url");

            entity.Property(e => e.UslugaId).HasColumnName("usluga_id");

            entity.HasOne(d => d.Usluga)
                .WithMany(p => p.Slike)
                .HasForeignKey(d => d.UslugaId)
                .OnDelete(DeleteBehavior.Cascade) 
                .HasConstraintName("FK__Slike__usluga_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
