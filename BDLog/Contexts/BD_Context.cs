using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BDELog.Models;

#nullable disable

namespace BDELog.Contexts
{
    public partial class BD_Context : DbContext
    {
        public BD_Context()
        {
        }

        public BD_Context(DbContextOptions<BD_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BdpfArea> BdpfAreas { get; set; }
        public virtual DbSet<BdpfBdpfma> BdpfBdpfmas { get; set; }
        public virtual DbSet<BdpfCausecode> BdpfCausecodes { get; set; }
        public virtual DbSet<BdpfCell> BdpfCells { get; set; }
        public virtual DbSet<BdpfContmeasurecode> BdpfContmeasurecodes { get; set; }
        public virtual DbSet<BdpfDamagecode> BdpfDamagecodes { get; set; }
        public virtual DbSet<BdpfEm> BdpfEms { get; set; }
        public virtual DbSet<BdpfFault> BdpfFaults { get; set; }
        public virtual DbSet<BdpfIdum> BdpfIda { get; set; }
        public virtual DbSet<BdpfMaint> BdpfMaints { get; set; }
        public virtual DbSet<BdpfMc> BdpfMcs { get; set; }
        public virtual DbSet<BdpfMcsubunit> BdpfMcsubunits { get; set; }
        public virtual DbSet<BdpfMcunit> BdpfMcunits { get; set; }
        public virtual DbSet<BdpfOp> BdpfOps { get; set; }
        public virtual DbSet<BdpfUsername> BdpfUsernames { get; set; }
        public virtual DbSet<BdpfUserrole> BdpfUserroles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TESTDB")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<BdpfArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("BDPF_AREA_PK");

                entity.Property(e => e.AreaId).HasPrecision(9);

                entity.Property(e => e.AreaInactive).HasPrecision(1);

                entity.Property(e => e.AreaName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfBdpfma>(entity =>
            {
                entity.HasKey(e => e.BdId)
                    .HasName("BDPF_BDPFMA_PK");

                entity.Property(e => e.BdId).HasPrecision(18);

                entity.Property(e => e.BdAddinfo).IsUnicode(false);

                entity.Property(e => e.BdAnalysis).HasPrecision(1);

                entity.Property(e => e.BdCont).HasPrecision(9);

                entity.Property(e => e.BdContmeas).HasPrecision(1);

                entity.Property(e => e.BdContmeasdesc).IsUnicode(false);

                entity.Property(e => e.BdCost).HasPrecision(18);

                entity.Property(e => e.BdCreatedby).HasPrecision(9);

                entity.Property(e => e.BdCuz).HasPrecision(9);

                entity.Property(e => e.BdDmg).HasPrecision(9);

                entity.Property(e => e.BdEm).HasPrecision(9);

                entity.Property(e => e.BdFault).HasPrecision(9);

                entity.Property(e => e.BdFaultdesc).IsUnicode(false);

                entity.Property(e => e.BdIdaneed).HasPrecision(1);

                entity.Property(e => e.BdInactive).HasPrecision(1);

                entity.Property(e => e.BdM2p).IsUnicode(false);

                entity.Property(e => e.BdMaint).HasPrecision(9);

                entity.Property(e => e.BdModifiedby).HasPrecision(9);

                entity.Property(e => e.BdOp).HasPrecision(9);

                entity.Property(e => e.BdPaperok).HasPrecision(1);

                entity.Property(e => e.BdPart).IsUnicode(false);

                entity.Property(e => e.BdRepeat).HasPrecision(1);

                entity.Property(e => e.BdStandard).HasPrecision(1);

                entity.Property(e => e.BdSub).HasPrecision(9);

                entity.Property(e => e.BdTime).HasPrecision(9);

                entity.HasOne(d => d.BdContNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdCont)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_CONTMEASURECODE");

                entity.HasOne(d => d.BdCuzNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdCuz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_CAUSECODE");

                entity.HasOne(d => d.BdDmgNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdDmg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_DAMAGECODE");

                entity.HasOne(d => d.BdEmNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdEm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_EM");

                entity.HasOne(d => d.BdFaultNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdFault)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_FAULT");

                entity.HasOne(d => d.BdMaintNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdMaint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_MAINT");

                entity.HasOne(d => d.BdOpNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdOp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_OP");

                entity.HasOne(d => d.BdSubNavigation)
                    .WithMany(p => p.BdpfBdpfmas)
                    .HasForeignKey(d => d.BdSub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_BDPFMA_BDPF_MCSUBUNIT");
            });

            modelBuilder.Entity<BdpfCausecode>(entity =>
            {
                entity.HasKey(e => e.CuzId)
                    .HasName("BDPF_CAUSECODE_PK");

                entity.Property(e => e.CuzId).HasPrecision(9);

                entity.Property(e => e.CuzCode).IsUnicode(false);

                entity.Property(e => e.CuzName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfCell>(entity =>
            {
                entity.HasKey(e => e.CellId)
                    .HasName("BDPF_CELL_PK");

                entity.Property(e => e.CellId).HasPrecision(9);

                entity.Property(e => e.CellArea).HasPrecision(9);

                entity.Property(e => e.CellInactive).HasPrecision(1);

                entity.Property(e => e.CellName).IsUnicode(false);

                entity.Property(e => e.CellNo).HasPrecision(2);

                entity.HasOne(d => d.CellAreaNavigation)
                    .WithMany(p => p.BdpfCells)
                    .HasForeignKey(d => d.CellArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_CELL_BDPF_AREA");
            });

            modelBuilder.Entity<BdpfContmeasurecode>(entity =>
            {
                entity.HasKey(e => e.ContId)
                    .HasName("BDPF_CONTMEASURECODE_PK");

                entity.Property(e => e.ContId).HasPrecision(9);

                entity.Property(e => e.ContCode).IsUnicode(false);

                entity.Property(e => e.ContName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfDamagecode>(entity =>
            {
                entity.HasKey(e => e.DmgId)
                    .HasName("BDPF_DAMAGECODE_PK");

                entity.Property(e => e.DmgId).HasPrecision(9);

                entity.Property(e => e.DmgCode).IsUnicode(false);

                entity.Property(e => e.DmgName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfEm>(entity =>
            {
                entity.HasKey(e => e.BdpfId)
                    .HasName("BDPF_EM_PK");

                entity.Property(e => e.BdpfId).HasPrecision(9);

                entity.Property(e => e.BdpfName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfFault>(entity =>
            {
                entity.HasKey(e => e.FaultId)
                    .HasName("BDPF_FAULT_PK");

                entity.Property(e => e.FaultId).HasPrecision(9);

                entity.Property(e => e.FaultName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfIdum>(entity =>
            {
                entity.HasKey(e => e.IdaId)
                    .HasName("BDPF_IDA_PK");

                entity.Property(e => e.IdaId).HasPrecision(9);

                entity.Property(e => e.IdaBd).HasPrecision(18);

                entity.Property(e => e.IdaEnded).HasPrecision(1);

                entity.Property(e => e.IdaStarted).HasPrecision(1);

                entity.HasOne(d => d.IdaBdNavigation)
                    .WithMany(p => p.BdpfIda)
                    .HasForeignKey(d => d.IdaBd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_IDA_BDPF_BDPFMA");
            });

            modelBuilder.Entity<BdpfMaint>(entity =>
            {
                entity.HasKey(e => e.MaintId)
                    .HasName("BDPF_MAINT_PK");

                entity.Property(e => e.MaintId).HasPrecision(9);

                entity.Property(e => e.MaintName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfMc>(entity =>
            {
                entity.HasKey(e => e.McId)
                    .HasName("BDPF_MC_PK");

                entity.Property(e => e.McId).HasPrecision(9);

                entity.Property(e => e.McCell).HasPrecision(9);

                entity.Property(e => e.McInactive).HasPrecision(1);

                entity.Property(e => e.McName).IsUnicode(false);

                entity.HasOne(d => d.McCellNavigation)
                    .WithMany(p => p.BdpfMcs)
                    .HasForeignKey(d => d.McCell)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_MC_BDPF_CELL");
            });

            modelBuilder.Entity<BdpfMcsubunit>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("BDPF_MCSUBUNIT_PK");

                entity.Property(e => e.SubId).HasPrecision(9);

                entity.Property(e => e.SubInactive).HasPrecision(1);

                entity.Property(e => e.SubMcunit).HasPrecision(9);

                entity.Property(e => e.SubName).IsUnicode(false);

                entity.Property(e => e.SubSap).IsUnicode(false);

                entity.HasOne(d => d.SubMcunitNavigation)
                    .WithMany(p => p.BdpfMcsubunits)
                    .HasForeignKey(d => d.SubMcunit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_MCSUBUNIT_BDPF_MCUNIT");
            });

            modelBuilder.Entity<BdpfMcunit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("BDPF_MCUNIT_PK");

                entity.Property(e => e.UnitId).HasPrecision(9);

                entity.Property(e => e.UnitInactive).HasPrecision(1);

                entity.Property(e => e.UnitMc).HasPrecision(9);

                entity.Property(e => e.UnitName).IsUnicode(false);

                entity.Property(e => e.UnitSap).IsUnicode(false);

                entity.HasOne(d => d.UnitMcNavigation)
                    .WithMany(p => p.BdpfMcunits)
                    .HasForeignKey(d => d.UnitMc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BDPF_MCUNIT_BDPF_MC");
            });

            modelBuilder.Entity<BdpfOp>(entity =>
            {
                entity.HasKey(e => e.OpId)
                    .HasName("BDPF_OP_PK");

                entity.Property(e => e.OpId).HasPrecision(9);

                entity.Property(e => e.OpName).IsUnicode(false);
            });

            modelBuilder.Entity<BdpfUsername>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("BDPF_USERNAMES_PK");

                entity.Property(e => e.UserId).HasPrecision(9);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.UserRole).HasPrecision(9);

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.BdpfUsernames)
                    .HasForeignKey(d => d.UserRole)
                    .HasConstraintName("BDPF_ROLE_BDPF_USERNAMES");
            });

            modelBuilder.Entity<BdpfUserrole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("BDPF_USERROLES_PK");

                entity.Property(e => e.RoleId).HasPrecision(9);

                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
