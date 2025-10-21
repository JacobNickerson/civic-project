using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    using Api.Models;
    public class TVDbContext : DbContext
    {
        public TVDbContext(DbContextOptions<TVDbContext> options) : base(options) {} 
        public DbSet<User> Users { get; set; }
        public DbSet<Auth> Auth { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<UserInConversation> ConversationMembers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventFollow> EventFollows { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<PetitionSignature> PetitionSignatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting Primary Keys
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Auth>().HasKey(a => a.UserId);
            modelBuilder.Entity<Conversation>().HasKey(c => c.Id);
            modelBuilder.Entity<UserInConversation>().HasKey(uc => new { uc.UserId, uc.ConversationId });
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<EventFollow>().HasKey(ef => new { ef.UserId, ef.EventId });
            modelBuilder.Entity<Post>().UseTptMappingStrategy().HasKey(p => p.Id);
            modelBuilder.Entity<PostReaction>().HasKey(pl => new { pl.UserId, pl.PostId } );
            modelBuilder.Entity<Petition>();
            modelBuilder.Entity<PetitionSignature>().HasKey(ps => new { ps.UserId, ps.PetitionId } );

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());
            }

            // Setting Foreign Keys/Relationships
            modelBuilder.Entity<Auth>()
                .HasOne(a => a.User)
                .WithOne(u => u.Auth)
                .HasForeignKey<Auth>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserInConversation>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Conversations)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserInConversation>()
                .HasOne(uc => uc.Conversation)
                .WithMany(u => u.Users)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Author)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventFollow>()
                .HasOne(ef => ef.User)
                .WithMany(u => u.FollowedEvents)
                .HasForeignKey(ef => ef.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EventFollow>()
                .HasOne(ef => ef.Event)
                .WithMany(e => e.Followers)
                .HasForeignKey(ef => ef.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostReaction>()
                .HasOne(pr => pr.Author)
                .WithMany(u => u.Reactions)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostReaction>()
                .HasOne(pr => pr.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(pr => pr.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PetitionSignature>()
                .HasOne(ps => ps.User)
                .WithMany(u => u.SignedPetitions)
                .HasForeignKey(ps => ps.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PetitionSignature>()
                .HasOne(ps => ps.Petition)
                .WithMany(p => p.Signatures)
                .HasForeignKey(ps => ps.PetitionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
