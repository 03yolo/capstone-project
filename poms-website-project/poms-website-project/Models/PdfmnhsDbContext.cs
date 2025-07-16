using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace poms_website_project;

public partial class PdfmnhsDbContext : DbContext
{
    public PdfmnhsDbContext()
    {
    }

    public PdfmnhsDbContext(DbContextOptions<PdfmnhsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminDetail> AdminDetails { get; set; }

    public virtual DbSet<AssessmentGrade> AssessmentGrades { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FacultyLoad> FacultyLoads { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<HomeCarouselItem> HomeCarouselItems { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentLearner> ParentLearners { get; set; }

    public virtual DbSet<Quarter> Quarters { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SchoolForm> SchoolForms { get; set; }

    public virtual DbSet<SchoolYear> SchoolYears { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionEnrolment> SectionEnrolments { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASUS-LORENZE\\SQLEXPRESS;Database=PDFMNHS_DB;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminDetail>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__AdminDet__719FE4E8688AA102");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Office)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Admin).WithOne(p => p.AdminDetail)
                .HasForeignKey<AdminDetail>(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdminDeta__Admin__5BE2A6F2");
        });

        modelBuilder.Entity<AssessmentGrade>(entity =>
        {
            entity.HasKey(e => e.AssessmentGradeId).HasName("PK__Assessne__C7083764A1287763");

            entity.Property(e => e.AssessmentGradeId).HasColumnName("AssessmentGradeID");
            entity.Property(e => e.AssessmentType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FacultyId).HasColumnName("FacultyID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.QuarterId).HasColumnName("QuarterID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Faculty).WithMany(p => p.AssessmentGrades)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assessnen__Facul__114A936A");

            entity.HasOne(d => d.Learner).WithMany(p => p.AssessmentGrades)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assessnen__Learn__0F624AF8");

            entity.HasOne(d => d.Quarter).WithMany(p => p.AssessmentGrades)
                .HasForeignKey(d => d.QuarterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assessnen__Quart__123EB7A3");

            entity.HasOne(d => d.Subject).WithMany(p => p.AssessmentGrades)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assessnen__Subje__10566F31");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263CFA6723D0");

            entity.ToTable("Attendance");

            entity.HasIndex(e => new { e.LearnerId, e.SchoolDate }, "UQ_Attendance").IsUnique();

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.Learner).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Learn__0C85DE4D");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E5499A8092A8E9F");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LogTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RecordPk)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("RecordPK");
            entity.Property(e => e.TableName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__Faculty__306F636E55DEAD18");

            entity.ToTable("Faculty");

            entity.HasIndex(e => e.EmployeeNo, "UQ__Faculty__7AD0F1B7A9D4514E").IsUnique();

            entity.Property(e => e.FacultyId)
                .ValueGeneratedNever()
                .HasColumnName("FacultyID");
            entity.Property(e => e.Designation)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FacultyNavigation).WithOne(p => p.Faculty)
                .HasForeignKey<Faculty>(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Faculty__Faculty__5FB337D6");
        });

        modelBuilder.Entity<FacultyLoad>(entity =>
        {
            entity.HasKey(e => e.LoadId).HasName("PK__FacultyL__4ED77A2DACB0D6BA");

            entity.Property(e => e.LoadId).HasColumnName("LoadID");
            entity.Property(e => e.FacultyId).HasColumnName("FacultyID");
            entity.Property(e => e.SchoolYearId).HasColumnName("SchoolYearID");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Faculty).WithMany(p => p.FacultyLoads)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FacultyLo__Facul__70DDC3D8");

            entity.HasOne(d => d.SchoolYear).WithMany(p => p.FacultyLoads)
                .HasForeignKey(d => d.SchoolYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FacultyLo__Schoo__73BA3083");

            entity.HasOne(d => d.Section).WithMany(p => p.FacultyLoads)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FacultyLo__Secti__72C60C4A");

            entity.HasOne(d => d.Subject).WithMany(p => p.FacultyLoads)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FacultyLo__Subje__71D1E811");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A376D9E0DBA");

            entity.HasIndex(e => new { e.LearnerId, e.SubjectId }, "UQ_LearnerQuarterSubject").IsUnique();

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.EncodedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FacultyId).HasColumnName("FacultyID");
            entity.Property(e => e.FinalGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.PtPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PT_Percentage");
            entity.Property(e => e.PtScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PT_Score");
            entity.Property(e => e.PtTotal)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PT_Total");
            entity.Property(e => e.QaPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("QA_Percentage");
            entity.Property(e => e.QaScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("QA_Score");
            entity.Property(e => e.QaTotal)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("QA_Total");
            entity.Property(e => e.Quarter)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.WwPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("WW_Percentage");
            entity.Property(e => e.WwScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("WW_Score");
            entity.Property(e => e.WwTotal)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("WW_Total");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__FacultyI__07C12930");

            entity.HasOne(d => d.Learner).WithMany(p => p.Grades)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__LearnerI__06CD04F7");

            entity.HasOne(d => d.Subject).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__SubjectI__08B54D69");
        });

        modelBuilder.Entity<HomeCarouselItem>(entity =>
        {
            entity.HasKey(e => e.CarouselItemId).HasName("PK__HomeCaro__5BF54AE953FB3FD5");

            entity.Property(e => e.CarouselItemId).HasColumnName("CarouselItemID");
            entity.Property(e => e.CaptionText)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CaptionTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DisplayOrder).HasDefaultValue(1);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerId).HasName("PK__Learners__67ABFCFA94AE553C");

            entity.HasIndex(e => e.Lrn, "UQ__Learners__C6569E5F3CDC0460").IsUnique();

            entity.Property(e => e.LearnerId)
                .ValueGeneratedNever()
                .HasColumnName("LearnerID");
            entity.Property(e => e.Lrn)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LRN");

            entity.HasOne(d => d.LearnerNavigation).WithOne(p => p.Learner)
                .HasForeignKey<Learner>(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Learners__Learne__6383C8BA");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E325ADFC2DA");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Message).HasMaxLength(400);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__1CBC4616");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parents__D339510F2D157466");

            entity.Property(e => e.ParentId)
                .ValueGeneratedNever()
                .HasColumnName("ParentID");

            entity.HasOne(d => d.ParentNavigation).WithOne(p => p.Parent)
                .HasForeignKey<Parent>(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Parents__ParentI__66603565");
        });

        modelBuilder.Entity<ParentLearner>(entity =>
        {
            entity.HasKey(e => new { e.ParentId, e.LearnerId }).HasName("PK__ParentLe__6543EEC055705A12");

            entity.ToTable("ParentLearner");

            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.Relationship)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.ParentLearners)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentLea__Learn__6A30C649");

            entity.HasOne(d => d.Parent).WithMany(p => p.ParentLearners)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentLea__Paren__693CA210");
        });

        modelBuilder.Entity<Quarter>(entity =>
        {
            entity.HasKey(e => e.QuarterId).HasName("PK__Quarters__1D2BD182DEA4BBC1");

            entity.Property(e => e.QuarterId).HasColumnName("QuarterID");
            entity.Property(e => e.SchoolYearId).HasColumnName("SchoolYearID");

            entity.HasOne(d => d.SchoolYear).WithMany(p => p.Quarters)
                .HasForeignKey(d => d.SchoolYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quarters__School__4E88ABD4");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AF54376A8");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160782B0C40").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SchoolForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__SchoolFo__FB05B7BDF2DD399C");

            entity.Property(e => e.FormId).HasColumnName("FormID");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FormType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GeneratedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.GeneratedByNavigation).WithMany(p => p.SchoolForms)
                .HasForeignKey(d => d.GeneratedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SchoolFor__Gener__17F790F9");

            entity.HasOne(d => d.Learner).WithMany(p => p.SchoolForms)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SchoolFor__Learn__17036CC0");
        });

        modelBuilder.Entity<SchoolYear>(entity =>
        {
            entity.HasKey(e => e.SchoolYearId).HasName("PK__SchoolYe__9BAABCC0A8DD2EEF");

            entity.HasIndex(e => e.StartYear, "UQ__SchoolYe__C03C467CCDC70810").IsUnique();

            entity.Property(e => e.SchoolYearId).HasColumnName("SchoolYearID");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF0892527B7044");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.SectionName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SectionEnrolment>(entity =>
        {
            entity.HasKey(e => e.EnrolId).HasName("PK__SectionE__605C7376BE20F1A2");

            entity.HasIndex(e => new { e.LearnerId, e.SchoolYearId }, "UQ_LearnerPerSY").IsUnique();

            entity.Property(e => e.EnrolId).HasColumnName("EnrolID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.SchoolYearId).HasColumnName("SchoolYearID");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");

            entity.HasOne(d => d.Learner).WithMany(p => p.SectionEnrolments)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionEn__Learn__778AC167");

            entity.HasOne(d => d.SchoolYear).WithMany(p => p.SectionEnrolments)
                .HasForeignKey(d => d.SchoolYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionEn__Schoo__797309D9");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionEnrolments)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionEn__Secti__787EE5A0");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA388E57388D5");

            entity.HasIndex(e => e.SubjectCode, "UQ__Subjects__9F7CE1A925D30B06").IsUnique();

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC131729D4");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053466F565A7").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
