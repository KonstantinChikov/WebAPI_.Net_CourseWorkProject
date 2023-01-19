using CWProject.Models.Models;
using System.Security.Cryptography;

namespace CWProject.Data.SeedData
{
    public class DbInitializer
    {

        // Seed for LocationType
        public static LocationType[] GetLocations()
        {
            var location = new LocationType[]
            {
                new LocationType { Name = "Sea"},
                new LocationType { Name = "Mountain"},
                new LocationType { Name = "City"},
                new LocationType { Name = "Village"}
            };
            return location;
        }

        // Seed for Amenities
        public static Amenities[] GetAmenities()
        {
            var amenities = new Amenities[]
            {
                new Amenities { Name = "Gym"},
                new Amenities { Name = "Spa"},
                new Amenities { Name = "Swimming Pool"},
                new Amenities { Name = "Restaurant"}
            };
            return amenities;
        }

        // Seed For Roles
        private static Role[] GetRoles()
        {
            var roles = new Role[]
            {
                new Role { Name = "User"},
                new Role { Name = "Admin"}
            };
            return roles;
        }

        // Seed For Admin
        private static User[] GetUsers()
        {
            var users = new User[]
            {
                new User
                {
                    Username = "admin",
                    Role = GetRoles()[1],
                    PasswordSalt = new HMACSHA512().Key,
                    PasswordHash = new HMACSHA512().ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"))
                }
            };
            return users;
        }

        public static void Seed(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(GetRoles());
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(GetUsers());
            }

            if (!context.Amenities.Any())
            {
                context.Amenities.AddRange(GetAmenities());
            }

            if (!context.LocationTypes.Any())
            {
                context.LocationTypes.AddRange(GetLocations());
            }

            context.SaveChanges();
        }

    }
}
