using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Camp Ross", ImageUrl="https://i.insider.com/60dc93caa08b100012b417e9?width=910&format=jpeg"},
        new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Camp Derek", ImageUrl="https://www.alapark.com/sites/default/files/2020-08/dsp_primitive_campground_19.jpg"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Camp Taylor", ImageUrl="https://terrain-mag.com/wp-content/uploads/2020/02/Barbara_150825_0697.jpg"},
        new Campsite {Id = 5, CampsiteTypeId = 2, Nickname = "Camp Andrew", ImageUrl="https://thervadvisor.com/wp-content/uploads/2018/12/Road-Tripping-Tips-for-Choosing-Your-RV-Campsite-e1545074276760.png"},
        new Campsite {Id = 6, CampsiteTypeId = 1, Nickname = "Camp NSS", ImageUrl="https://www.armstrongwatson.co.uk/sites/armstrongwatson.co.uk/files/styles/blog/adaptive-image/public/news-images/2021/campsite_with_tents.jpg?itok=w6XzCVU2"},
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
        new UserProfile {Id = 1, FirstName = "Andrew", LastName = "Spurlock", Email = "bigbabyspur@gmail.com"},
        });
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
{
        new Reservation {Id = 1, CampsiteId = 5, UserProfileId = 1, CheckinDate = new DateTime(2024, 07, 01), CheckoutDate = new DateTime(2024, 07, 04)},
});

    }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
}