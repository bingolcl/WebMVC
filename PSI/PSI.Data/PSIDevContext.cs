using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PSI.Data
{
    public partial class PSIDevContext : DbContext
    {
        public PSIDevContext()
        {
        }

        public PSIDevContext(DbContextOptions<PSIDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<ActivityLogType> ActivityLogType { get; set; }
        public virtual DbSet<ControllerAction> ControllerAction { get; set; }
        public virtual DbSet<ControllerActionRole> ControllerActionRole { get; set; }
        public virtual DbSet<Eejra> Eejra { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Psi> Psi { get; set; }
        public virtual DbSet<QueuedEmail> QueuedEmail { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Submission> Submission { get; set; }
        public virtual DbSet<TechInRole> TechInRole { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }
        public virtual DbSet<TimeZone> TimeZone { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInRole> UserInRole { get; set; }
        public virtual DbSet<Vacation> Vacation { get; set; }
        public virtual DbSet<WorkingAlone> WorkingAlone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQLAPP;Initial Catalog=PSIDev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActivityLogType)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.ActivityLogTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityLog_ActivityLogType");
            });

            modelBuilder.Entity<ActivityLogType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ControllerAction>(entity =>
            {
                entity.Property(e => e.ActionName)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ControllerActionRole>(entity =>
            {
                entity.HasOne(d => d.ControllerAction)
                    .WithMany(p => p.ControllerActionRole)
                    .HasForeignKey(d => d.ControllerActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ControllerActionRole_ControllerAction");
            });

            modelBuilder.Entity<Eejra>(entity =>
            {
                entity.ToTable("EEJRA");

                entity.Property(e => e.ArcFlashExemptions)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IpAddress).HasMaxLength(200);

                entity.Property(e => e.ShortMessage).IsRequired();

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Psi>(entity =>
            {
                entity.ToTable("PSI");

                entity.Property(e => e.EnergizedWorkPpe).HasColumnName("EnergizedWorkPPE");

                entity.Property(e => e.OtherHazards)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Ppe).HasColumnName("PPE");
            });

            modelBuilder.Entity<QueuedEmail>(entity =>
            {
                entity.Property(e => e.Bcc).HasMaxLength(500);

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FromName).HasMaxLength(500);

                entity.Property(e => e.ReplyTo).HasMaxLength(500);

                entity.Property(e => e.ReplyToName).HasMaxLength(500);

                entity.Property(e => e.SentOn).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(1000);

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ToName).HasMaxLength(500);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.Property(e => e.Ccemail)
                    .HasColumnName("CCEmail")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittedDateTime).HasColumnType("datetime");

                entity.Property(e => e.TechnicianId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TechInRole>(entity =>
            {
                entity.HasKey(e => new { e.TechnicianId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TechInRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechInRole_Role");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.TechInRole)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechInRole_Technician");
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicianId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.TimeZoneNavigation)
                    .WithMany(p => p.Technician)
                    .HasForeignKey(d => d.TimeZone)
                    .HasConstraintName("FK_Technician_TimeZone");
            });

            modelBuilder.Entity<TimeZone>(entity =>
            {
                entity.HasKey(e => e.TimeZoneTag)
                    .HasName("PK_TimeZone_1");

                entity.Property(e => e.TimeZoneTag)
                    .HasColumnName("Time_Zone_Tag")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GmtOffsetHours).HasColumnName("GMT_Offset_Hours");

                entity.Property(e => e.TimeZoneDescription)
                    .IsRequired()
                    .HasColumnName("Time_Zone_Description")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AdUsername)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInRole_User");
            });

            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.Vacation)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacation_Technician");
            });

            modelBuilder.Entity<WorkingAlone>(entity =>
            {
                entity.Property(e => e.Location)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.MergencyContactName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.MergencyContactPhone)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });
        }
    }
}
