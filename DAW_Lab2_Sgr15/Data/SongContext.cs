using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DAW_Lab2_Sgr15.Data
{
    public class SongContext: IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public SongContext(DbContextOptions<SongContext> options): base(options)
        {
            
        }
        
        public DbSet<SessionToken> SessionTokens { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<UserSong> UserSongs { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Many to Many
            modelBuilder.Entity<UserSong>()
                .HasKey(us => new { us.UserId, us.SongId });

            modelBuilder.Entity<UserSong>()
                .HasOne(us => us.Song)
                .WithMany(us => us.UserSongs)
                .HasForeignKey(us => us.SongId);

            modelBuilder.Entity<UserSong>()
                .HasOne(us => us.User)
                .WithMany(us => us.UserSongs)
                .HasForeignKey(us => us.UserId);

            //One to One
            modelBuilder.Entity<User>()
                .HasOne(us => us.PersonalInfo)
                .WithOne(pc => pc.User);

            //One to Many
            modelBuilder.Entity<User>()
                .HasMany(usr => usr.Playlists)
                .WithOne(pl => pl.User);

            //Many to Many
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(pls => new { pls.SongId, pls.PlaylistId });

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(pls => pls.Song)
                .WithMany(pls => pls.PlaylistSongs)
                .HasForeignKey(pls => pls.SongId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(pls => pls.Playlist)
                .WithMany(pls => pls.PlaylistSongs)
                .HasForeignKey(pls => pls.PlaylistId);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });
        }
    }
}
