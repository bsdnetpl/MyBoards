using Microsoft.EntityFrameworkCore;

namespace MyBoards.Entities
{
    public class MyBoardsContext : DbContext
    {
        public MyBoardsContext(DbContextOptions<MyBoardsContext> options) : base(options)
        {

        }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorkItemStates> WorkItemStates{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WorkItem>()  // lepiej tak jak na dole
            //       .Property(x => x.State)
            //       .IsRequired();
            //modelBuilder.Entity<WorkItem>()
            //    .Property(x => x.Area)
            //    .HasColumnType("varchar(200)");

            modelBuilder.Entity<WorkItemStates>()
                .Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Epic>()
                .Property(wi => wi.EnddDate).
                HasPrecision(3);

            modelBuilder.Entity<Task>()
                .Property(wi => wi.Activity)
                .HasMaxLength(200);
            modelBuilder.Entity<Task>()
                .Property(wi => wi.RemaningWork)
                .HasPrecision(14, 2);
            modelBuilder.Entity<Issue>()
                .Property(wi => wi.Effort)
                .HasColumnType("decimal(5,2)");



            modelBuilder.Entity<WorkItem>(eb =>
              {

                  eb.HasOne(w => w.State)
                   .WithMany()
                   .HasForeignKey(w => w.StateId);

                  eb.Property(x => x.Area).HasColumnType("varchar(200)");
                  eb.Property(wi => wi.InterationPath).HasColumnName("Iteration_Path");
                  eb.Property(wi => wi.Prioryti).HasDefaultValue(1);
                  eb.HasMany(w => w.Comments) // jeden do wielu
                  .WithOne(c => c.WorkItem)
                  .HasForeignKey(c => c.WorkItemId);

                  eb.HasOne(w => w.Author)
                  .WithMany(u => u.WorkItems)
                  .HasForeignKey(w => w.AuthorId);

                  eb.HasMany(w => w.Tags) // wiele do wielu tabela łacząca
                  .WithMany(t => t.WorkItems)
                  .UsingEntity<WorkItemTag>(

                      w => w.HasOne(wit => wit.Tag)
                      .WithMany()
                      .HasForeignKey(wit => wit.TagId),

                      w => w.HasOne(wit => wit.WorkItem)
                      .WithMany()
                      .HasForeignKey(wit => wit.WorkItemId),

                       wit =>
                       {
                           wit.HasKey(x => new { x.TagId, x.WorkItemId });
                           wit.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                       }


                      );
              });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.UpdateDate).ValueGeneratedOnUpdate();
                eb.HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>() // 1 do 1 relacja
                .HasOne(u => u.Address)
                .WithOne(u => u.User)
                .HasForeignKey<Address>(a => a.UserId);

            //modelBuilder.Entity<WorkItemTag>()
            //     .HasKey(c => new { c.TagId, c.WorkItemId });

            modelBuilder.Entity<WorkItemStates>() // dodawanie defaultowych danych seedowanie
                .HasData(new WorkItemStates() {id=1, Value = "To Do" },
                new WorkItemStates() { id = 2, Value = "Doing" },
                new WorkItemStates() { id = 3, Value = "Done" });

            modelBuilder.Entity<Tag>()
                .HasData(new Tag() { Id = 1, Value = "Web" },
                new Tag() { Id = 2, Value = "UI" },
                new Tag() { Id = 3, Value = "Desktop" },
                new Tag() { Id = 4, Value = "API" },
                new Tag() { Id = 5, Value = "Services" });


        }


    }
}
