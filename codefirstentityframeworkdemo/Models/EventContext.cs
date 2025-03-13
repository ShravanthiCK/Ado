using Microsoft.EntityFrameworkCore;

namespace codefirstentityframeworkdemo.Models
{
    public class EventContext:DbContext
    {
        public EventContext()
        {

        }

        public EventContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Author> authors { get; set; }

        public DbSet<Course> courses { get; set; }

        public DbSet<Student> students { get; set; }

        public DbSet<UserDetail> userdetails { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Author1> authors1 { get; set; }

        public DbSet<Course1> courses1 { get; set; }

        public DbSet<Course2> courses2 { get; set; }

        public DbSet<Author2> authors2 { get; set; }

        public DbSet<UserDetail2> userdetails2 { get; set; }

        public DbSet<Post> posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // Fluent API for Author2
            modelBuilder.Entity<Author2>(entity =>
            {



                entity.HasKey(a => a.Id); // Primary Key
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);

                // Relationship with Course2
                entity.HasMany(a => a.Courses)
                      .WithOne(c => c.Author)
                      .HasForeignKey(c => c.Author2Id)
                      .OnDelete(DeleteBehavior.Cascade); // Cascade delete
            });

            // Fluent API for Course2
            modelBuilder.Entity<Course2>(entity =>
            {
                entity.HasKey(c => c.Id); // Primary Key

                entity.Property(c => c.Id)
                      .ValueGeneratedNever(); // Not an identity column

                entity.Property(c => c.Title)
                      .IsRequired()
                      .HasMaxLength(255)
                      .HasColumnName("Stitle")
                      .HasColumnType("varchar");

                entity.Property(c => c.Description)
                      .IsRequired()
                      .HasMaxLength(220);

                entity.Property(c => c.fullprice)
                      .HasColumnType("float")
                      .IsRequired();

                // Foreign Key to Author1
                entity.HasOne(c => c.Author)
                      .WithMany(a => a.Courses)
                      .HasForeignKey(c => c.Author2Id);
            });


            // Fluent API for UserDetail
            modelBuilder.Entity<UserDetail2>(entity =>
            {
                entity.HasKey(u => u.Id); // Primary Key

                entity.Property(u => u.UserName)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(u => u.NewPassword)
                      .IsRequired()
                      .HasMaxLength(11);

                entity.Property(u => u.DateOfBirth)
                      .IsRequired()
                      .HasColumnType("date");

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(100)
                      .HasColumnType("varchar");

                entity.Property(u => u.PostalCode)
                      .IsRequired()
                      .HasColumnType("int");

                entity.Property(u => u.PhoneNo)
                      .IsRequired();

                entity.Property(u => u.Profile)
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");
            });

            // Seed data for Author1 and Course1
            modelBuilder.Entity<Author2>().HasData(
                new Author2 { Id = 1, Name = "Author One" },
                new Author2 { Id = 2, Name = "Author Two" }
            );

            modelBuilder.Entity<Course2>().HasData(
                new Course2 { Id = 1, Title = "Course A", Description = "Description A", fullprice = 100, Author2Id = 1 },
                new Course2 { Id = 2, Title = "Course B", Description = "Description B", fullprice = 200, Author2Id = 2 }
            );
        }



    }
}
