using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Election.CORE.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eabout> Eabouts { get; set; }
        public virtual DbSet<Eaboutu> Eaboutus { get; set; }
        public virtual DbSet<Ebloodtype> Ebloodtypes { get; set; }
        public virtual DbSet<Ecandidate> Ecandidates { get; set; }
        public virtual DbSet<Ecandidateform> Ecandidateforms { get; set; }
        public virtual DbSet<Ecategory> Ecategories { get; set; }
        public virtual DbSet<Econtactu> Econtactus { get; set; }
        public virtual DbSet<Eelectionduration> Eelectiondurations { get; set; }
        public virtual DbSet<Egender> Egenders { get; set; }
        public virtual DbSet<Egovernorate> Egovernorates { get; set; }
        public virtual DbSet<Ehome> Ehomes { get; set; }
        public virtual DbSet<Emunicipalname> Emunicipalnames { get; set; }
        public virtual DbSet<Emunicipalstatus> Emunicipalstatuses { get; set; }
        public virtual DbSet<Eplaceandregnum> Eplaceandregnums { get; set; }
        public virtual DbSet<Eplaceofrelease> Eplaceofreleases { get; set; }
        public virtual DbSet<Eplaceofresidence> Eplaceofresidences { get; set; }
        public virtual DbSet<Eplaceofresidencevillage> Eplaceofresidencevillages { get; set; }
        public virtual DbSet<Eplaceswithinthemunicipal> Eplaceswithinthemunicipals { get; set; }
        public virtual DbSet<Ereview> Ereviews { get; set; }
        public virtual DbSet<Erole> Eroles { get; set; }
        public virtual DbSet<Etestimonial> Etestimonials { get; set; }
        public virtual DbSet<Euser> Eusers { get; set; }
        public virtual DbSet<Euserinformation> Euserinformations { get; set; }
        public virtual DbSet<Euservote> Euservotes { get; set; }
        public virtual DbSet<Euservoted> Euservoteds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=JOR15_User67;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR15_USER67")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Eabout>(entity =>
            {
                entity.ToTable("EABOUT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Aboutimage1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTIMAGE1");

                entity.Property(e => e.Aboutimage2)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTIMAGE2");

                entity.Property(e => e.Aboutimage3)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTIMAGE3");

                entity.Property(e => e.Abouttitle1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTTITLE1");

                entity.Property(e => e.Abouttitle2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTTITLE2");

                entity.Property(e => e.Abouttitle3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTTITLE3");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Eabouts)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ABOUTUSHOME");
            });

            modelBuilder.Entity<Eaboutu>(entity =>
            {
                entity.ToTable("EABOUTUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phonenumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONENUMBER");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Eaboutus)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ABOUTHOME");
            });

            modelBuilder.Entity<Ebloodtype>(entity =>
            {
                entity.ToTable("EBLOODTYPE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Bloodtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BLOODTYPE");
            });

            modelBuilder.Entity<Ecandidate>(entity =>
            {
                entity.ToTable("ECANDIDATES");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Candidateformid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CANDIDATEFORMID");

                entity.Property(e => e.Candidateimagepath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CANDIDATEIMAGEPATH");

                entity.Property(e => e.Candidatename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANDIDATENAME");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Des)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DES");

                entity.Property(e => e.Municipalstatusid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MUNICIPALSTATUSID");

                entity.Property(e => e.Resultstatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RESULTSTATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Candidateform)
                    .WithMany(p => p.Ecandidates)
                    .HasForeignKey(d => d.Candidateformid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00307353");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Ecandidates)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("SYS_C00307351");

                entity.HasOne(d => d.Municipalstatus)
                    .WithMany(p => p.Ecandidates)
                    .HasForeignKey(d => d.Municipalstatusid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00307352");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ecandidates)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C00307354");
            });

            modelBuilder.Entity<Ecandidateform>(entity =>
            {
                entity.ToTable("ECANDIDATEFORM");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Acceptstatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCEPTSTATUS");

                entity.Property(e => e.Candidatename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANDIDATENAME");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Ecandidateforms)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("SYS_C00307337");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ecandidateforms)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C00307338");
            });

            modelBuilder.Entity<Ecategory>(entity =>
            {
                entity.ToTable("ECATEGORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Econtactu>(entity =>
            {
                entity.ToTable("ECONTACTUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Econtactus)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_COUNTHOME");
            });

            modelBuilder.Entity<Eelectionduration>(entity =>
            {
                entity.ToTable("EELECTIONDURATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Electionenddate)
                    .HasPrecision(0)
                    .HasColumnName("ELECTIONENDDATE");

                entity.Property(e => e.Electionstartdate)
                    .HasPrecision(0)
                    .HasColumnName("ELECTIONSTARTDATE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Eelectiondurations)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("EELECTIONDURATION_FK1");
            });

            modelBuilder.Entity<Egender>(entity =>
            {
                entity.ToTable("EGENDER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");
            });

            modelBuilder.Entity<Egovernorate>(entity =>
            {
                entity.ToTable("EGOVERNORATE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Governoratename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GOVERNORATENAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");
            });

            modelBuilder.Entity<Ehome>(entity =>
            {
                entity.ToTable("EHOME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Homeimage1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("HOMEIMAGE1");

                entity.Property(e => e.Homeimage2)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("HOMEIMAGE2");

                entity.Property(e => e.Homeimage3)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("HOMEIMAGE3");

                entity.Property(e => e.Hometitle1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOMETITLE1");

                entity.Property(e => e.Hometitle2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOMETITLE2");

                entity.Property(e => e.Hometitle3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOMETITLE3");
            });

            modelBuilder.Entity<Emunicipalname>(entity =>
            {
                entity.ToTable("EMUNICIPALNAME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Municipalname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MUNICIPALNAME");
            });

            modelBuilder.Entity<Emunicipalstatus>(entity =>
            {
                entity.ToTable("EMUNICIPALSTATUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Decentralized)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DECENTRALIZED");

                entity.Property(e => e.Governorateid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GOVERNORATEID");

                entity.Property(e => e.Memebers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MEMEBERS");

                entity.Property(e => e.Municipalnameid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MUNICIPALNAMEID");

                entity.Property(e => e.President)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRESIDENT");

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Emunicipalstatuses)
                    .HasForeignKey(d => d.Governorateid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00307342");

                entity.HasOne(d => d.Municipalname)
                    .WithMany(p => p.Emunicipalstatuses)
                    .HasForeignKey(d => d.Municipalnameid)
                    .HasConstraintName("SYS_C00307341");
            });

            modelBuilder.Entity<Eplaceandregnum>(entity =>
            {
                entity.ToTable("EPLACEANDREGNUM");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Placeandregnum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLACEANDREGNUM");
            });

            modelBuilder.Entity<Eplaceofrelease>(entity =>
            {
                entity.ToTable("EPLACEOFRELEASE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Placeofrelease)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLACEOFRELEASE");
            });

            modelBuilder.Entity<Eplaceofresidence>(entity =>
            {
                entity.ToTable("EPLACEOFRESIDENCE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Placeofresidence)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLACEOFRESIDENCE");
            });

            modelBuilder.Entity<Eplaceofresidencevillage>(entity =>
            {
                entity.ToTable("EPLACEOFRESIDENCEVILLAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Placeofresidencevillage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PLACEOFRESIDENCEVILLAGE");
            });

            modelBuilder.Entity<Eplaceswithinthemunicipal>(entity =>
            {
                entity.ToTable("EPLACESWITHINTHEMUNICIPAL");

                entity.HasIndex(e => e.Placeofresidencevillageid, "SYS_C00307345")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Municipalstatusid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MUNICIPALSTATUSID");

                entity.Property(e => e.Placeofresidenceid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEOFRESIDENCEID");

                entity.Property(e => e.Placeofresidencevillageid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEOFRESIDENCEVILLAGEID");

                entity.HasOne(d => d.Municipalstatus)
                    .WithMany(p => p.Eplaceswithinthemunicipals)
                    .HasForeignKey(d => d.Municipalstatusid)
                    .HasConstraintName("SYS_C00307348");

                entity.HasOne(d => d.Placeofresidence)
                    .WithMany(p => p.Eplaceswithinthemunicipals)
                    .HasForeignKey(d => d.Placeofresidenceid)
                    .HasConstraintName("SYS_C00307346");

                entity.HasOne(d => d.Placeofresidencevillage)
                    .WithOne(p => p.Eplaceswithinthemunicipal)
                    .HasForeignKey<Eplaceswithinthemunicipal>(d => d.Placeofresidencevillageid)
                    .HasConstraintName("SYS_C00307347");
            });

            modelBuilder.Entity<Ereview>(entity =>
            {
                entity.ToTable("EREVIEW");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Opinion)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OPINION");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ereviews)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVUSER");
            });

            modelBuilder.Entity<Erole>(entity =>
            {
                entity.ToTable("EROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Etestimonial>(entity =>
            {
                entity.ToTable("ETESTIMONIAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Acceptstatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCEPTSTATUS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Etestimonials)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TESTHOME");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Etestimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TESTUSER");
            });

            modelBuilder.Entity<Euser>(entity =>
            {
                entity.ToTable("EUSER");

                entity.HasIndex(e => e.Userinfoid, "SYS_C00307332")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Idbackimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IDBACKIMAGE");

                entity.Property(e => e.Idfrontimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IDFRONTIMAGE");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Ssn)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SSN");

                entity.Property(e => e.Userimagepath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USERIMAGEPATH");

                entity.Property(e => e.Userinfoid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERINFOID");

                entity.Property(e => e.Verified)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VERIFIED");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Eusers)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("SYS_C00307334");

                entity.HasOne(d => d.Userinfo)
                    .WithOne(p => p.Euser)
                    .HasForeignKey<Euser>(d => d.Userinfoid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00307333");
            });

            modelBuilder.Entity<Euserinformation>(entity =>
            {
                entity.ToTable("EUSERINFORMATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Bloodtypeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BLOODTYPEID");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Expiry)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Genderid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GENDERID");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Mothername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOTHERNAME");

                entity.Property(e => e.Placeandregnumid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEANDREGNUMID");

                entity.Property(e => e.Placeofbirthid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEOFBIRTHID");

                entity.Property(e => e.Placeofreleaseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEOFRELEASEID");

                entity.Property(e => e.Placeofresidenceid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEOFRESIDENCEID");

                entity.Property(e => e.Placeofresidencevillageid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLACEOFRESIDENCEVILLAGEID");

                entity.Property(e => e.Secondname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECONDNAME");

                entity.Property(e => e.Ssn)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SSN");

                entity.Property(e => e.Userimagepath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USERIMAGEPATH");

                entity.HasOne(d => d.Bloodtype)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Bloodtypeid)
                    .HasConstraintName("SYS_C00307329");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Genderid)
                    .HasConstraintName("SYS_C00307323");

                entity.HasOne(d => d.Placeandregnum)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Placeandregnumid)
                    .HasConstraintName("SYS_C00307325");

                entity.HasOne(d => d.Placeofbirth)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Placeofbirthid)
                    .HasConstraintName("SYS_C00307324");

                entity.HasOne(d => d.Placeofrelease)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Placeofreleaseid)
                    .HasConstraintName("SYS_C00307326");

                entity.HasOne(d => d.Placeofresidence)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Placeofresidenceid)
                    .HasConstraintName("SYS_C00307327");

                entity.HasOne(d => d.Placeofresidencevillage)
                    .WithMany(p => p.Euserinformations)
                    .HasForeignKey(d => d.Placeofresidencevillageid)
                    .HasConstraintName("SYS_C00307328");
            });

            modelBuilder.Entity<Euservote>(entity =>
            {
                entity.ToTable("EUSERVOTE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Decentralized)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DECENTRALIZED");

                entity.Property(e => e.Memebers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MEMEBERS");

                entity.Property(e => e.President)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRESIDENT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.Property(e => e.Usermunicipalid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERMUNICIPALID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Euservotes)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C00307362");

                entity.HasOne(d => d.Usermunicipal)
                    .WithMany(p => p.Euservotes)
                    .HasForeignKey(d => d.Usermunicipalid)
                    .HasConstraintName("SYS_C00307363");
            });

            modelBuilder.Entity<Euservoted>(entity =>
            {
                entity.ToTable("EUSERVOTED");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Candidatesid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CANDIDATESID");

                entity.Property(e => e.Municipalstatusid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MUNICIPALSTATUSID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.Property(e => e.Votedate)
                    .HasPrecision(6)
                    .HasColumnName("VOTEDATE");

                entity.HasOne(d => d.Candidates)
                    .WithMany(p => p.Euservoteds)
                    .HasForeignKey(d => d.Candidatesid)
                    .HasConstraintName("SYS_C00307358");

                entity.HasOne(d => d.Municipalstatus)
                    .WithMany(p => p.Euservoteds)
                    .HasForeignKey(d => d.Municipalstatusid)
                    .HasConstraintName("SYS_C00307359");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Euservoteds)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C00307357");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
