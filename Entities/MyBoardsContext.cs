using Microsoft.EntityFrameworkCore;

namespace MyBoards.Entities
{
    public class MyBoardsContext : DbContext
    {
        public MyBoardsContext( DbContextOptions<MyBoardsContext> options) : base(options)
        {
          
        }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WorkItem>()  // lepiej tak jak na dole
            //       .Property(x => x.State)
            //       .IsRequired();
            //modelBuilder.Entity<WorkItem>()
            //    .Property(x => x.Area)
            //    .HasColumnType("varchar(200)");


            modelBuilder.Entity<WorkItem>(eb =>
              {
                  eb.Property(x => x.State).IsRequired();
                  eb.Property(x => x.Area).HasColumnType("varchar(200)");
                  eb.Property(wi => wi.InterationPath).HasColumnName("Iteration_Path");
                  eb.Property(wi => wi.Effort).HasColumnType("decimal(5,2)");
                  eb.Property(wi => wi.EnddDate).HasPrecision(3);
                  eb.Property(wi => wi.Activity).HasMaxLength(200);
                  eb.Property(wi => wi.RemaningWork).HasPrecision(14, 2);
                  eb.Property(wi => wi.Prioryti).HasDefaultValue(1);
              });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.UpdateDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<User>() // 1 do 1 relacja
                .HasOne(u => u.Address)
                .WithOne(u => u.User)
                .HasForeignKey<Address>(a => a.UserId);


        }


    }
}
