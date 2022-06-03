using Curate.Data.ViewModels.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Curate.Data.Models
{
    public partial class curatedbContext : IdentityDbContext<ApplicationUser>
    {
        public curatedbContext()
        {
        }

        public curatedbContext(DbContextOptions<curatedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<RssFeed> RssFeeds { get; set; }
        public virtual DbSet<RssFeedArticle> RssFeedArticles { get; set; }
        public virtual DbSet<RssFeedError> RssFeedErrors { get; set; }
        public virtual DbSet<RssFeedSubtype> RssFeedSubtypes { get; set; }
        public virtual DbSet<RssFeedType> RssFeedTypes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagPost> TagPosts { get; set; }
        public virtual DbSet<TagRssFeedArticle> TagRssFeedArticles { get; set; }
        public virtual DbSet<TagVideoChannel> TagVideoChannels { get; set; }
        public virtual DbSet<UserAuditEvent> UserAuditEvents { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoChannel> VideoChannels { get; set; }
        public virtual DbSet<VideoPlaylist> VideoPlaylists { get; set; }
        public virtual DbSet<VideoPlaylistVideo> VideoPlaylistVideos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=curatedb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<RssFeed>(entity =>
            {
                entity.ToTable("RssFeed");

                entity.Property(e => e.BlockedReason).HasMaxLength(250);

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.RssFeedSubType)
                    .WithMany(p => p.RssFeeds)
                    .HasForeignKey(d => d.RssFeedSubTypeId)
                    .HasConstraintName("FK_RssFeed_RssFeedSubtype");
            });

            modelBuilder.Entity<RssFeedArticle>(entity =>
            {
                entity.ToTable("RssFeedArticle");

                entity.Property(e => e.Blurb).HasMaxLength(250);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.RssFeed)
                    .WithMany(p => p.RssFeedArticles)
                    .HasForeignKey(d => d.RssFeedId)
                    .HasConstraintName("FK_RssFeedArticle_RssFeed");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.RssFeedArticles)
                    .HasForeignKey(d => d.VideoId)
                    .HasConstraintName("FK_RssFeedArticle_Video");
            });

            modelBuilder.Entity<RssFeedError>(entity =>
            {
                entity.ToTable("RssFeedError");

                entity.Property(e => e.ErrorDate).HasColumnType("date");

                entity.Property(e => e.ErrorMessage).IsRequired();

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<RssFeedSubtype>(entity =>
            {
                entity.ToTable("RssFeedSubtype");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.ParentType)
                    .WithMany(p => p.RssFeedSubtypes)
                    .HasForeignKey(d => d.ParentTypeId)
                    .HasConstraintName("FK_RssFeedSubtype_RssFeedType");
            });

            modelBuilder.Entity<RssFeedType>(entity =>
            {
                entity.ToTable("RssFeedType");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<TagPost>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.PostId })
                    .HasName("PK_dbo.TagPost");

                entity.ToTable("TagPost");

                entity.HasIndex(e => e.PostId, "IX_Post_Id");

                entity.HasIndex(e => e.TagId, "IX_Tag_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.Property(e => e.PostId).HasColumnName("Post_Id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TagPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_dbo.TagPost_dbo.Post_Post_Id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagPosts)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.TagPost_dbo.Tag_Tag_Id");
            });

            modelBuilder.Entity<TagRssFeedArticle>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.TagId })
                    .HasName("PK_RssFeedArticleTag2");

                entity.ToTable("TagRssFeedArticle");

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TagRssFeedArticles)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagRssFeedArticle_RssFeedArticle");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagRssFeedArticles)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagRssFeedArticle_Tag");
            });

            modelBuilder.Entity<TagVideoChannel>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.VideoChannelId });

                entity.ToTable("TagVideoChannel");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.Property(e => e.VideoChannelId).HasColumnName("VideoChannel_Id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagVideoChannels)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagVideoChannel_Tag");

                entity.HasOne(d => d.VideoChannel)
                    .WithMany(p => p.TagVideoChannels)
                    .HasForeignKey(d => d.VideoChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagVideoChannel_VideoChannel");
            });

            modelBuilder.Entity<UserAuditEvent>(entity =>
            {
                entity.HasKey(e => e.UserAuditId);

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Slug).HasMaxLength(250);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.VideoUrl).IsRequired();

                entity.Property(e => e.YoutubeCategory).HasMaxLength(250);

                entity.Property(e => e.YoutubeChannelId).HasMaxLength(250);

                entity.Property(e => e.YoutubeChannelTitle).HasMaxLength(250);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_Video_VideoChannel");
            });

            modelBuilder.Entity<VideoChannel>(entity =>
            {
                entity.ToTable("VideoChannel");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ChannelCreationDate).HasColumnType("date");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Slug).HasMaxLength(250);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.VideoChannel)
                    .HasForeignKey<VideoChannel>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoChannel_RssFeed");
            });

            modelBuilder.Entity<VideoPlaylist>(entity =>
            {
                entity.ToTable("VideoPlaylist");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Slug).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.YoutubeChannelId).HasMaxLength(250);

                entity.Property(e => e.YoutubeChannelTitle).HasMaxLength(250);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.VideoPlaylists)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoPlaylist_VideoChannel");
            });

            modelBuilder.Entity<VideoPlaylistVideo>(entity =>
            {
                entity.HasKey(e => new { e.VideoPlaylistId, e.VideoId });

                entity.ToTable("VideoPlaylistVideo");

                entity.Property(e => e.VideoPlaylistId).HasColumnName("VideoPlaylist_Id");

                entity.Property(e => e.VideoId).HasColumnName("Video_Id");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.VideoPlaylistVideos)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoPlaylistVideo_Video");

                entity.HasOne(d => d.VideoPlaylist)
                    .WithMany(p => p.VideoPlaylistVideos)
                    .HasForeignKey(d => d.VideoPlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoPlaylistVideo_VideoPlaylist");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
